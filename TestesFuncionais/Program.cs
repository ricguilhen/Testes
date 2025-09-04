using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace TestesFuncionais;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Iniciando a execução dos testes funcionais...");

        // execução dos testes
        TestLoginValido_SauceDemo();
        TestLoginValido_TheInternet();
        TestLoginValido_PracticeTestAutomation();
        TestLoginValido_OrangeHRM();

        Console.WriteLine("\nTodos os testes foram concluídos.");
        Console.WriteLine("Pressione qualquer tecla para fechar a janela...");
        Console.ReadKey(); // mantém o console aberto para eu ver o resultado
    }

    // - CASO DE TESTE 1 SauceDemo CT-SD-001 -
    public static void TestLoginValido_SauceDemo()
    {
        Console.WriteLine("\n--- Testando SauceDemo ---");
        IWebDriver driver = null;
        try
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com");

            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();

            Thread.Sleep(2000);

            string expectedUrl = "https://www.saucedemo.com/inventory.html";
            if (driver.Url == expectedUrl)
            {
                Console.WriteLine("Resultado: PASS");
            }
            else
            {
                Console.WriteLine($"Resultado: FAIL - URL esperada: {expectedUrl}, mas a URL atual é: {driver.Url}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Resultado: FAIL - Ocorreu um erro: {ex.Message}");
        }
        finally
        {
            driver?.Quit();
        }
    }

    // - CASO DE TESTE 2 TheInternet CT-TI-001 -
    public static void TestLoginValido_TheInternet()
    {
        Console.WriteLine("\n--- Testando TheInternet ---");
        IWebDriver driver = null;
        try
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            Thread.Sleep(2000);

            IWebElement successMessage = driver.FindElement(By.Id("flash"));
            if (successMessage.Text.Contains("You logged into a secure area!"))
            {
                Console.WriteLine("Resultado: PASS");
            }
            else
            {
                Console.WriteLine($"Resultado: FAIL - A mensagem de sucesso não foi encontrada.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Resultado: FAIL - Ocorreu um erro: {ex.Message}");
        }
        finally
        {
            driver?.Quit();
        }
    }

    // - CASO DE TESTE 3 PracticeTestAutomation CT-PTA-001 -
    public static void TestLoginValido_PracticeTestAutomation()
    {
        Console.WriteLine("\n--- Testando PracticeTestAutomation ---");
        IWebDriver driver = null;
        try
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");

            driver.FindElement(By.Id("username")).SendKeys("student");
            driver.FindElement(By.Id("password")).SendKeys("Password123");
            driver.FindElement(By.Id("submit")).Click();

            Thread.Sleep(2000);

            string expectedUrl = "https://practicetestautomation.com/logged-in-successfully/";
            if (driver.Url == expectedUrl)
            {
                Console.WriteLine("Resultado: PASS");
            }
            else
            {
                Console.WriteLine($"Resultado: FAIL - URL esperada: {expectedUrl}, mas a URL atual é: {driver.Url}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Resultado: FAIL - Ocorreu um erro: {ex.Message}");
        }
        finally
        {
            driver?.Quit();
        }
    }

    // - CASO DE TESTE 4 OrangeHRM CT-OHRM-001 -
    public static void TestLoginValido_OrangeHRM()
    {
        Console.WriteLine("\n--- Testando OrangeHRM ---");
        IWebDriver driver = null;
        try
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");

            // site tava lento, aumentei o tempo de espera
            Thread.Sleep(5000);

            driver.FindElement(By.Name("username")).SendKeys("Admin");
            driver.FindElement(By.Name("password")).SendKeys("admin123");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            Thread.Sleep(5000);

            string expectedUrlPart = "/web/index.php/dashboard/index";
            if (driver.Url.Contains(expectedUrlPart))
            {
                Console.WriteLine("Resultado: PASS");
            }
            else
            {
                Console.WriteLine($"Resultado: FAIL - URL não contém '{expectedUrlPart}'. URL atual é: {driver.Url}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Resultado: FAIL - Ocorreu um erro: {ex.Message}");
        }
        finally
        {
            driver?.Quit();
        }
    }
}
csharp
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://google.com");
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("screenshot.png");
        }
    }
}

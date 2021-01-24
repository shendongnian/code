c#
// Install-Package Selenium.WebDriver
// Install-Package Selenium.WebDriver.ChromeDriver -Version 75.0.3770.140
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;
namespace Selenium_Screenshot_SaveAsFile
{
    public class DriverFactory
    {
        public static IWebDriver setDriver(string name)
        {
            return new ChromeDriver();
        }
    }
    public class Helper
    {
        public static void TakeScreenshot(string value)
        {
            IWebDriver driver;
            driver = DriverFactory.setDriver("Chrome");
            driver.Navigate().GoToUrl(value);
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            // This succeeds because it's saving to a file...
            ss.SaveAsFile(Path.Combine(Helper.GetScreenShotDirectory(), "Hello, world!.png"), ScreenshotImageFormat.Png);
            // System.UnauthorizedAccessException because it's trying to overwrite a directory...
            ss.SaveAsFile(Helper.GetScreenShotDirectory(), ScreenshotImageFormat.Png);
        }
        public static string GetScreenShotDirectory()
        {
            string cur = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string screenshotDir = Path.Combine(cur, @"..\..\", "Screenshots");
            SetAccessRule(screenshotDir);
            return screenshotDir;
        }
        public static void SetAccessRule(string directory)
        {
            System.Security.AccessControl.DirectorySecurity sec = System.IO.Directory.GetAccessControl(directory);
            FileSystemAccessRule accRule = new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, FileSystemRights.FullControl, AccessControlType.Allow);
            sec.AddAccessRule(accRule);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Helper.TakeScreenshot("https://stackoverflow.com/");
        }
    }
}

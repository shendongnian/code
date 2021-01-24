    using OpenQA.Selenium;
    using OpenQA.Selenium.Edge;
    using System;
    
    namespace EdgeDriverTests
    {
        public class Program
        {
            /*
            * This assumes you have added MicrosoftWebDriver.exe to your System Path.
            * For help on adding an exe to your System Path, please see:
            * https://msdn.microsoft.com/en-us/library/office/ee537574(v=office.14).aspx
            */
            static void Main(string[] args)
            {
                /* You can find the latest version of Microsoft WebDriver here:
                * https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/
                */
                var driver = new EdgeDriver();
    
                // Navigate to Bing
                driver.Url = "https://www.bing.com/";
    
                // Find the search box and query for webdriver
                var element = driver.FindElementById("sb_form_q");
    
                element.SendKeys("webdriver");
                element.SendKeys(Keys.Enter);
    
                Console.ReadLine();
                driver.Quit();
            }
        }
    }

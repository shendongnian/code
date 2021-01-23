        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using OpenQA.Selenium;
        using OpenQA.Selenium.IE;
        using OpenQA.Selenium.Support.UI;
    
        namespace SeleniumTest
        {
            class Program
            {
                static void Main(string[] args)
                {
    
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                
                    IWebDriver driver = new InternetExplorerDriver("C:\\Selenium",options);
    
                
                    driver.Navigate().GoToUrl("http://www.stackoverflow.com");
                }
            }
        }

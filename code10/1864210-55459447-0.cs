    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Support.UI;
    using System;
    
    class Program {
        static void Main(string[] args) {
            string geckoDriverPath = @"D:\Downloads\geckodriver-v0.24.0-win64";
            using (var driver = new FirefoxDriver(geckoDriverPath)) {
                driver.Navigate().GoToUrl("https://stackoverflow.com");
                var searchBox = driver.FindElementByCssSelector("#search .js-search-field");
                searchBox.SendKeys("Selenium");
    
                var searchButton = driver.FindElementByCssSelector("#search .js-search-submit");
                searchButton.Click();
                Console.Read();
            }
        }
    }

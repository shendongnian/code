    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium.IE;
    
    
    
    namespace Selenium_HelloWorld
    {
        class Program
        {
            static void Main(string[] args)
            {
                IWebDriver driver = new InternetExplorerDriver("C:\\");
                driver.Navigate().GoToUrl("http://108.178.174.137");
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("inputName")).SendKeys("apatra");
                driver.FindElement(By.Id("inputPassword")).SendKeys("asd");
                driver.FindElement(By.Name("DoLogin")).Click();
                
                string output = driver.FindElement( By.XPath(".//*[@id='tab-general']/div/div[2]/div[1]/div[2]/div/strong")).Text;
                
                if (output != null  )
                {
                    Console.WriteLine("Test Passed :) ");
                }
                else
                {
                    Console.WriteLine("Test Failed");
                }
            }
    
            
            }
    }

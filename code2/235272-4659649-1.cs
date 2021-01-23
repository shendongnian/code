    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using OpenQA.Selenium.IE;
    
    namespace Selenium2
    {
        class SelectExample
        {
            public static void Main(string[] args)
            {
                IWebDriver driver = new InternetExplorerDriver();
                driver.Navigate().GoToUrl("www.example.com");
                //note how here's i'm passing in a normal IWebElement to the Select
                // constructor
                Select select = new Select(driver.FindElement(By.Id("select")));
                IList<IWebElement> options = select.GetOptions();
                foreach (IWebElement option in options)
                {
                    System.Console.WriteLine(option.Text);
                }
                select.SelectByValue("audi");
                
                //This is only here so you have time to read the output and 
                System.Console.ReadLine();
                driver.Quit();
    
            }
        }
    }

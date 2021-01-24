    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Edge;
    
    public class webdriver
    {
        static void Main(string[] args)
        {    
            IWebDriver AzimaHome = new EdgeDriver();
            AzimaHome.Navigate().GoToUrl("http:www.msn.com");
    
            IList<IWebElement> terms = AzimaHome.FindElements(By.TagName("a"));
            terms.First(element => element.Text == "msn").Click();
        }
    }

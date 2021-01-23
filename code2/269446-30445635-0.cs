    using System;
    using System.Collections.Generic;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Support.UI;
    
    namespace SeleniumTests {
        class DropDownListSelection {
            static void Main(string[] args) {
                IWebDriver driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("http://YourDDListpageURL.html");
                IWebElement element = driver.FindElement(By.XPath("//Select"));
                //You can locate the element by using the ID / Name as well IList
                AllDropDownList = element.FindElements(By.XPath("//option"));
                int DpListCount = AllDropDownList.Count;
                for (int i = 0; i < DpListCount; i++) {
                    if (AllDropDownList[i].Text == "Coffee") {
                        AllDropDownList[i].Click();
                    }
                }
                Console.WriteLine(DpListCount);
                Console.ReadLine();
            }
        }
    }

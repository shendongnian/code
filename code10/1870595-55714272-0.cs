    public void TestChromeDriverMinimalWaitTime()
            {
                driver.Navigate().GoToUrl("http://www.google.com");
                //find search bar and enter text
                driver.FindElement(By.Name("q")).SendKeys("Selenium");
               
                //...unless button element is found
               while(!IsElementVisible(driver.FindElement(By.Name("btnK"))){
                      Thread.Sleep(1000);
                      }
                //once found, click the button
                waitUntil.Click();
                //wait 4 secs till this test method ends
                Thread.Sleep(2000);
            }
    
    public bool IsElementVisible(IWebElement element)
    {
        return element.Displayed && element.Enabled;
    }

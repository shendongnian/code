     using (IWebDriver driver = new 
     ChromeDriver(options))
    {
       Thread.Sleep(8000);    // or higher
       driver.Navigate().GoToUrl(url);        
       driver.FindElement(By.Name("lgin")).Click();
       // Thread.Sleep(8000);    // or higher
       // try this upper line if you need it
       driver.FindElement(By.Id("Img2")).Click();
    }

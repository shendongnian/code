    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    IWebElement element= wait.Until(ExpectedConditions.ElementToBeClickable(By.Xpath("/html/body/div[6]//a[1]")));
    
    element.Click();

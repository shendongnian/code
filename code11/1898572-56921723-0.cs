    var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10));
    var enterRace = wait
        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions
        .ElementExists(By.XPath("//a[text()='Enter a typing race']")));
    enterRace.Click();

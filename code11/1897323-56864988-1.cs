    driver.Navigate().GoToUrl("http://google.com");
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    IWebElement searchBar = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("q")));
    searchBar.SendKeys("Hello world!");
    IWebElement searchButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("btnK")));
    searchButton.Click();
    driver.Quit();

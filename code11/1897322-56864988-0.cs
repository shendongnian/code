    driver.Navigate().GoToUrl("http://google.com");
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    var searchBar = wait.Until(ExpectedConditions.ElementIsClickable(By.Name("q")));
    searchBar.Submit();
    searchBar.SendKeys("Hello world!");
    var searchButton = wait.Until(ExpectedConditions.ElementIsClickable(By.Name("btnK")));
    searchButton.Click();
    driver.Quit();

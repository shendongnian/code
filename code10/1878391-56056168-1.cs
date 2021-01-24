    public IWebElement WaitForElementVisible(By locator, TimeSpan timeout)
    {
        WebDriverWait wait = new WebDriverWait(driver, timeout);
        IWebElement element = wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(locator));
    }

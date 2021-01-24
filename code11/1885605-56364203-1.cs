    public IWebElement WaitForPresence(By locator)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(locator));
    }
    public IWebElement WaitForVisible(By locator)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(locator));
    }
    public IWebElement WaitForClickable(By locator)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(locator));
    }

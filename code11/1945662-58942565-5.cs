    public IWebElement waitForVisibility(By element)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(5))
        .Until(x=>SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element)); //the lambda depends on your context.
    }

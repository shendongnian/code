    // Replace IElement by the actual return type of By.Id, By.Name, By.XPath!
    public static void click(this IWebDriver webDriver, Func<string, IElement> by, String elementLocator)
    {
        webDriver.FindElement(by(elementLocator)).Click();
    }
    // Convenience methods
    public static void clickById(this IWebDriver webDriver, String elementLocator)
    {
        webDriver.click(By.Id, elementLocator);
    }
    public static void clickByName(this IWebDriver webDriver, String elementLocator)
    {
        webDriver.click(By.Name, elementLocator);
    }
    public static void clickByXPath(this IWebDriver webDriver, String elementLocator)
    {
        webDriver.click(By.XPath, elementLocator);
    }

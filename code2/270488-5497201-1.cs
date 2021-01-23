    // Replace IElement by the actual return type of By.Id, By.Name, By.XPath!
    public static void click(IWebDriver webDriver, Func<string, IElement> by, String elementLocator)
    {
        webDriver.FindElement(by(elementLocator)).Click();
    }

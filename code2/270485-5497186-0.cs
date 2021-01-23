    public static void ClickElement(this IWebDriver webDriver, Element element)
    {
        webDriver.FindElement(element).Click();
    }
    
    public static void ClickElementById(this IWebDriver webDriver, string elementLocator)
    {
        webDriver.ClickElement(By.Id(elementLocator));
    }
    
    public static void ClickElementByName(this IWebDriver webDriver, string elementLocator)
    {
        webDriver.ClickElement(By.Name(elementLocator));
    }
    
    public static void ClickElementByXPath(this IWebDriver webDriver, string elementLocator)
    {
        webDriver.ClickElement(By.XPath(elementLocator));
    }

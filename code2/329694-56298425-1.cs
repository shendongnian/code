    public static IWebElement WaitForObject(IWebDriver DriverObj, By by, int TimeOut = 30)
    {
        try
        {
            WebDriverWait Wait1 = new WebDriverWait(DriverObj, TimeSpan.FromSeconds(TimeOut));
            var WaitS = Wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            return WaitS[0];
        }
        catch (NoSuchElementException)
        {
            Reports.TestStep("Wait for Element(s) with xPath was failed in current context page.");
            throw;
        }
    }

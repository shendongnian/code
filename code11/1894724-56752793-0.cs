    public static Func<IWebDriver, IWebElement> ElementIsVisible(IWebElement element)
    {
        return (driver) =>
            {
                try
                {
                    return return element.Displayed ? element : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
    }

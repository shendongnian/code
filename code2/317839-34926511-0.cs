    public static void ClickAndWaitForNewPage(this IWebElement elementToClick, IWebDriver driver)
    {
    	elementToClick.Click();
    	new Wait(driver).Until(d => elementToClick.IsStale(), 5);
    }
    
    private static bool IsStale(this IWebElement elementToClick)
    {
    	try
    	{
    		//the following will raise an exception when called for any ID value
    		elementToClick.FindElement(By.Id("Irrelevant value"));
    		return false;
    	}
    	catch (StaleElementReferenceException)
    	{
    		return true;
    	}
    }

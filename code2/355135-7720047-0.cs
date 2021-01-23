    public void LaunchNewWindow(IWebElement element)
    {
        int windowsBefore = driver.WindowHandles.Count;
        element.Click();
    
        TimeSpan timeout = new TimeSpan(0, 0, 10);
        WebDriverWait wait = new WebDriverWait(driver, timeout);
    
        wait.Until((_driver) =>
        {
            return _driver.WindowHandles.Count != windowsBefore;
            //optionally use _driver.WindowHandles.Count > windowsBefore
        });
    }

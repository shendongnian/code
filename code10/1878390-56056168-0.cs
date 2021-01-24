    DefaultWait<IWebDriver> wait = new DefaultWait(driver);
    wait.Timeout = TimeSpan.FromSeconds(1);
    wait.PollingInterval = TimeSpan.FromMilliseconds(100);
    wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
    IWebElement element = wait.Until<IWebElement>((d) =>
    {
        return d.FindElement(By.TagName("textarea"));
    });

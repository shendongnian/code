    public bool WaitForWebElementToBeNotPresent(IWebElement module)
    {
        var result = true;
        try
        {
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            if (module.Displayed)
            {
                result = true;
            }
        }
        catch (Exception)
        {
            result = false;
        }
        return result;
    }

    public static bool IsAlertPresent()
    {
        int secondsToWait = 1; //Wait for 1 second.
        try
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(secondsToWait)).Until(ExpectedConditions.AlertIsPresent());
            return true;
        }
        catch (WebDriverTimeoutException) { return false; }
    }

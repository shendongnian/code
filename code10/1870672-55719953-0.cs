    public static bool IsElementVisible(IWebDriver driver, String locator)
    {
        WebDriverWait wait = new WebDriverWait(driver,System.TimeSpan.FromMinutes(1));
        WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
        try
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.xpath(locator)));
        }
        catch (Exception ex)
        {
            ex.printStackTrace();
            return false;
        }
        return true;
    }

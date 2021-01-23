    [TearDown]
    public void TeardownTest()
    {
        try
        {
            if (Config.CLOSE_BROWSER_AFTER_TEST_CASE)
            {
                driver.Quit();
            }
        }
        catch (Exception)
        {
            // Ignore errors if unable to close the browser
        }
        Assert.AreEqual("", verificationErrors.ToString());
    }

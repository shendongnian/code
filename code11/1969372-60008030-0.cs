    foreach (IWebElement attachment in driver.FindElements(By.ClassName("attachment")))
    {
        attachment.Click();
        driver.FindElement(By.ClassName("delete-attachment")).Click();
        driver.SwitchTo().Alert().Accept();
    }

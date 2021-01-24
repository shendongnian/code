    WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(5)); // changed from 5000 because this is seconds and not milliseconds
    By blockUI = By.CssSelector(".blockUI.blockOverlay");
    waitForElement.Until(ExpectedConditions.VisibilityOfElementLocated(blockUI));
    waitForElement.Until(ExpectedConditions.InvisibilityOfElementLocated(blockUI));
    managedg.MAN_DistGroups.Click();

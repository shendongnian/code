            private bool IsElementPresent(By by)
            {
                try
                {
                    _driver.FindElement(by);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
            private void WaitForReady(By by)
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromHours(2));
                wait.Until(driver =>
                {
                    //bool isAjaxFinished = (bool)((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active == 0");
                    return IsElementPresent(by);
                });
            }
          // ...
          // Usage
          WaitForReady(By.ClassName("block-ui-message")); // It will wait until element which class name is 'block-ui-message' is presented to page

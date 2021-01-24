        public static void Click(IWebElement element)
        {
            var actions = new Actions(driver);
            actions.MoveToElement((element));
            actions.Click(element).Perform();
        }
        public static void JClick(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }
        public static void LastChanceClick(IWebElement element)
        {
            try
            {
                Click(element);
            }
            catch (Exception)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
            }
        }

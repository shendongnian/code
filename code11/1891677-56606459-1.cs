            public static void DragAndDrop(IWebElement element1, IWebElement element2)
        {
            WaitForElementEnabled(element1);
            WaitForElementEnabled(element2);
            var builder = new Actions(_webDriver);
            var dragAndDrop = builder.ClickAndHold(element1).MoveToElement(element2).Release(element2).Build();
            dragAndDrop.Perform();
        }
               public static void WaitForElementEnabled(IWebElement element)
        {
            try { _wait.Until(webDriver => element.Enabled); }
            catch (StaleElementReferenceException) { if (!WaitForNotFoundElement_Enabled(element)) { LogFunctions.WriteError("Enabled - Stale Element Exception"); TakeScreenshot("elementNotFound"); throw; } }
         }

            public static bool IsElementPresent_byXpath(string xpath)
        {
            bool result;
            try { result = Driver.FindElement(By.XPath(xpath)).Displayed; }
            catch (NoSuchElementException) { return false; }
            catch (StaleElementReferenceException) { return false; }
            return result;
        }

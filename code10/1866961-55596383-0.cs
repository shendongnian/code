        public bool IsNewPageLoaded(IWebElement elementToGoStale)
        {
            try
            {
                var enabled = elementToGoStale.Enabled;
                return false;
            }
            catch(Exception ex)
            {
                if (ex is StaleElementReferenceException || ex is NoSuchElementException)
                {
                    return true; // Expected exception on accessing stale element: page has been renewed
                }
                throw ex;
            }
        }

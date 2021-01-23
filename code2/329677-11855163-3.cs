        public static class IsPresent2
    {
        public static bool isPresent2(this IWebDriver driver, By bylocator)
        {
            bool variable = true; 
            try
            {
                IWebElement element = driver.FindElement(bylocator);
    
            }
            catch (NoSuchElementException)
            {
                variable = false; 
            }
            return variable; 
        }
    
    }

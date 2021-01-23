    public static class IsPresent
    {
        public static bool isPresent(this IWebDriver driver, By bylocator)
        {
            
            bool variable = false;
            try
            {
                IWebElement element = driver.FindElement(bylocator);
                variable = element != null;
            }
           catch (NoSuchElementException){
            
           }
            return variable; 
        }
       
    }

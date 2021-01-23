    public bool doesWebElementExist(string linkexist)
    {
         try
         {
            driver.FindElement(By.XPath(linkexist));
            return true;
         }
         catch (NoSuchElementException e)
         {
            return false;
         }
    }

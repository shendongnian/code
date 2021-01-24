    public async Task<bool> TryClick(By by, int mode = 0)
    {
       try
       {
           if (mode == 0)
           {
               Driver.ExecuteScript("arguments[0].click('');", ((RemoteWebDriver)Driver).FindElement(by));
           }
           else if (mode == 1)
           {
               Driver.FindElement(by).Click();
           }
           else if (mode == 2)
           {
               Actions action = new Actions(Driver);
               action.MoveToElement(Driver.FindElement(by)).Perform();
               action.Click(Driver.FindElement(by)).Perform();
           }
           return true;
       }
       catch (Exception ex) { }
       return false;
    }

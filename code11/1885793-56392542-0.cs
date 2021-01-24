           var waitForAddUser= new WebDriverWait(_webDriver, new TimeSpan(5000));
             waitForAddUser.IgnoreExceptionTypes(typeof(NoSuchElementException),
                     typeof(ElementNotVisibleException));
            waitForAddUser.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[ng- 
                   click*=AddUserBtnClick]")));
                
       

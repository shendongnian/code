    for (int count = 0; count < listCount; count++)
    {
        try
        {
            var selectElement   = new SelectElement(pageElement);
            selectElement.SelectByText(pagevalue);
            break;
        }
        catch (NoSuchElementException NSE)
        {
    
       driver.FindElement(By.Id("policyNumber")).SendKeys(policies[count]);
            driver.FindElement(By.Id("btnOK")).Click();
            continue;
        }  
        catch (Exception ex)
        {
           //Do something with other exception
        }  
    }

    wait.waitFrame("idFrame");
    driver.SwitchTo().Frame(driver.FindElement(By.Id("idFrame")));
            
    public void waitFrame(string idElement)
    {
       WebDriverWait wa = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
       wa.Until(c => c.FindElement(By.Id(idElement)));
    }

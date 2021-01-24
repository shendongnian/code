    public override void selectFiles()
    {
        //should you run base.selectFiles() before or after the loop? base.selectFiles() has no any logic?
        foreach (string key in searchKeys)// key is never used inside loop, serious?
        {
            IWebElement keyElement = base.getKeyElement("FC5");
            //getKeyElement support multiple keys, why do you always get FC5 in each loop? 
            //should you move above line out if no need to getkey again
            IWebElement parentElement = keyElement.FindElement(By.XPath("./parent::*"));
            IWebElement element = parentElement.FindElement(By.XPath("//*[contains(text(),'Download')]"));//is this `Download` the `key`?
            //where is this driver from? why not move this line out of loop
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click().Perform();
        }
    }
    // I simplified this code
    public IWebElement getKeyElement(string searchKeys)
    {
        var keys = string.Join(" and ", searchKeys.Split(",").Select(searchKey => $"contains(text(),'{searchKey}')"));
        //check keys in debug mode
        var element = waitForVisibility(By.XPath($"//*[{keys}]"));
        return element;
    }
    public IWebElement waitForVisibility(By element)
    {
        //I guess the issue is in Until. it is a Func<> but you may give it a result.
        return new WebDriverWait(driver, TimeSpan.FromSeconds(5))
        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
    }

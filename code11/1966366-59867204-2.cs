    using (IWebDriver driver = new ChromeDriver())
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
    
        driver.Navigate().GoToUrl("https://poshmark.com/create-listing");
    
        driver.FindElement(By.Id("login_form_username_email")).SendKeys("username");
        driver.FindElement(By.Id("login_form_password")).SendKeys("password");
        driver.FindElement(By.TagName("button")).Click();
    
        wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[data-vv-name='title']"))).SendKeys("Title controled by t3cho");
    
        driver.FindElement(By.CssSelector("[data-vv-name='originalPrice']")).SendKeys("22");
    
        var categoryCombobox = driver.FindElement(By.XPath("//span[@data-et-name='category']/ancestor::div[contains(@class,'isting-editor__input--half')][1]"));
        js.ExecuteScript("arguments[0].scrollIntoView(false)", categoryCombobox);
        categoryCombobox.Click();
    
        var category1 = driver.FindElement(By.LinkText("Accessories"));
        js.ExecuteScript("arguments[0].scrollIntoView(false)", category1);
        category1.Click();
    
        var category2 = driver.FindElement(By.LinkText("Glasses"));
        js.ExecuteScript("arguments[0].scrollIntoView(false)", category2);
        category2.Click();
    }
Download `SeleniumExtras.WaitHelpers` NuGet Package for `ExpectedConditions`.

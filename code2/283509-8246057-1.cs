    private IWebElement element;
    private void Method()
    {
      element = driver.FindElement(By.Id("txtUserName"));
      element.Clear();
      element.SendKeys("TEST");
      element = driver.FindElement(By.Id("txtPassword"));
      element.Clear();
      element.SendKeys("Test123");
      element = driver.FindElement(By.Id("buttonSignIn"));
      element.Click();
    }

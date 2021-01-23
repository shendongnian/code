    IWebElement usernameInput = driver.FindElement(By.Id("txtUserName"));
    usernameInput.SendKeys("TEST");
    IWebElement passwordInput = driver.FindElement(By.Id("txtPassword"));
    passwordInput.SendKeys("TEST123");
    IWebElement signinButton = driver.FindElement(By.Id("buttonSignIn"));
    signinButton.Click();

    var phone = driver.FindElement(By.Id("phones"));
    var phoneLi = phone.FindElements(By.TagName("li"));
    Actions action  = new Actions(driver);//simply my webdriver
    action.MoveToElement(phoneLi[1]).Perform();//move to list element that needs to be hovered
    var click = action.MoveToElement(phoneLi[1].FindElements(By.TagName("a"))[0];//move to actual button link after the 'Li' was hovered
    click.Click();
    click.Perform(); //not too sure why I needed to use both of these, but I did. Don't care, it works ;)
    IAlert alert = driver.SwitchTo().Alert();
    alert.Accept();

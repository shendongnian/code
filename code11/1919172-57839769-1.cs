WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitsec));
IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='']")));
element.click();
 2. It is possible that the element you are trying to click is in a frame, then you have to switch to that frame(let's say your frame name is investigationFRAME):
driver.SwitchTo().Frame(investigationFRAME);
WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitsec));
IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='']")));
element.click();
You are trying with wrong xpath please give a try to the following code:
IList<IWebElement> tooltip= driver.FindElements(By.XPath("//div[@class='IconContainer js-tooltip']/span[@class='Icon Icon--caretDownLight Icon--small']"));
tooltip.Click();

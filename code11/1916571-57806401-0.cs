//1. Hover mouse over "Change" and move it slightly to the left to open up the menu
var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
var DropDown1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(@class,'item-text')][contains(text(),'Change')]")));
Actions action = new Actions(driver);
action.MoveToElement(DropDown1).Perform();
action.MoveByOffset(-10, -10).Perform();
//2. Click on "Create Change Order"
wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(@class,'item-text')][contains(text(),'Create Change Order')]"))).Click();

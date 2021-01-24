`
using OpenQA.Selenium.Support.UI;
// declare wait of 15 seconds
var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
// wait for element to exist, then store it in username variable
var username = wait.Until(drv => drv.FindElement(By.Id("txt-username")));
// clear & send keys
username.Clear();
username.SendKeys("username");
`
The same approach can be repeated for password.
If you are still getting username / password invalid, and you are sure you are using correct credentials, then it's possible `SendKeys()` is happening too quickly & keystrokes are not all registering in the `input` fields..

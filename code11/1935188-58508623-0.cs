`
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Support.UI;
// need to wrap this in IPerformsTouchActions driver, not regular AndroidDriver
public void DragAndDrop(this IPerformsTouchActions driver, int startX, int startY, int endX, int endY)
{
    new TouchAction(driver).Press(startX, startY).MoveTo(endX, endY).Release().Perform();
}
`
We can call this method as such:
`
var fromElement = driver.FindElement(someLocator);
var toElement = driver.FindElement(someOtherLocator);
driver.DragAndDrop(fromElement.Coordinates.LocationOnScreen.X, fromElement.Coordinates.LocationOnScreen.Y, toElement.Coordinates.LocationOnScreen.X, toElement.Coordinates.LocationOnScreen.Y);
`
This should get you started hopefully. You can substitute `Press` with `LongPress`, or use `Press().Wait(500)` (ms). You may need to try out a few different options to get this working for your needs.

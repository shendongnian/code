public class MyTests
{
    private IWebDriver _webdriver = new ChromeDriver();
    [Fact]
    public void CarouselWithMultipleItems_ClickRightButton_NavigatesToNextItem()
    {
        // Arrange
        // Load page
        _webdriver.Url = "your-url-here";
        // Wait until right button is clickable
        WebDriverWait wait = new WebDriverWait(_webdriver, new TimeSpan(0, 0, 30));
        WebElement rightArrow = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("a.right.carousel-control")));
        // Act
        rightArrow.Click();
        // Assert
        WebElement caption = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("<caption-selector-here>")));
        // You might need another wait here
        WebElement picture = _webdriver.FindElement(By.CssSelector(".imgcarousel.active"));
        // Do your assert logic here
    }
}
Should get you started. It goes without saying that you will need to include the relevant xUnit NuGet pacakges
along with the Selenium.WebDriver, Selenium.Support, SeleniumChrome.WebDriver, and DotNetSeleniumExtras (there might be some other required ones too).

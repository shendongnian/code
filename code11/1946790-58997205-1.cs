`
public class Initializer
{
    IWebDriver driver = null;
    [SetUp]
    public void Before()
    {
        ChromeOptions options = new ChromeOptions();
        // some initial browser configuration here
        driver = new ChromeDriver(".");
    }
    [TearDown]
    public void After()
    {
        driver.Close();
    }
}
`
Then, `TestCases.cs`:
`
public class TestCases : Initializer // inherit initializer here
{
    [Test] // each time you run this test, [SetUp] runs first
    public void AutomatedTest()
    {
        driver.FindElement(); // driver class variable inherited from Initializer.cs
        // you can use driver to initialize PageObjects too
        var myPageObject = new MyPageObject(driver); 
        myPageObject.DoSomething();
    } // each time this test is completed, [TearDown] runs
}
`
This easily gives us a way to utilize the PageObject model, too, because you can initialize PageObjects on the test-case level.

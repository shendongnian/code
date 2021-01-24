`
public class DriverManager
{
    
    public IWebDriver CreateDriver
    {
        // code to initialize your WebDriver instance here
    }
    public void CloseWebDriverSession
    {
        Driver.Close();
        Driver.Quit();
    }
}
`
Next, here's a test case implementation that utilizes DriverManager to close & reopen WebDriver as needed.
`
public class TestBothQueues
{
    // this driver instance will keep track of your session throughout the test case
    public IWebDriver driver;
    [Test]
    public void ShouldRunBothQueues
    {
        // declare instance of DriverManager class
        DriverManager manager = new DriverManager();    
        // start a webdriver instance
        driver = manager.CreateDriver();
        // run the first queue
        RunFirstQueue();
        // terminate the WebDriver so we don't have browser open for 12 hours
        manager.CloseWebDriverSession();
        // wait 12 hours
        Thread.Sleep(TimeSpan.FromHours(12));
        // start another WebDriver session to start the second queue
        driver = manager.CreateDriver();
        // run the second queue
        RunSecondQueue();
        // terminate when we are finished
        manager.CloseWebDriverSession();
    }
}
`
A few notes on this:
You can also convert this code into a while loop if you would like to start a WebDriver instance to check the queue on a time interval. For example, if the queue takes 12-16 hours to finish, you may want to wait 12 hours, then check the queue once per hour until you can verify it is completed. That would look something like this:
`
// first, wait initial 12 hours
Thread.Sleep(TimeSpan.FromHours(12));
// keep track of whether or not queue is finished
bool isQueueFinished = false;
while (!isQueueFinished);
{
    // start webdriver instance to check the queue
    IWebDriver driver = manager.CreateDriver();
    
    // check if queue is finished
    isQueueFinished = CheckIfQueueFinished(driver);
    
    // if queue is finished, while loop will break
    // if queue is not finished, close the WebDriver instance, and start again
    if (!isQueueFinished)
    {
        // close the WebDriver since we won't need it
        manager.CloseWebDriverSession();
        // wait another hour
        Thread.Sleep(TimeSpan.FromHours(1));
    }
}
`
Hope this helps.

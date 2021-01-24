public class TimeableWebDriverWait : IWait<IWebDriver>
{
    private readonly Action<string> logger;
    private readonly IWait<IWebDriver> wait;
    public string Message
    {
        get => wait.Message;
        set => wait.Message = value;
    }
    public TimeSpan PollingInterval
    {
        get => wait.PollingInterval;
        set => wait.PollingInterval = value;
    }
    public TimeSpan Timeout
    {
        get => wait.Timeout;
        set => wait.Timeout = value;
    }
    public TimeableWebDriverWait(IWait<IWebDriver> wait, Action<string> logger = null)
    {
        this.wait = wait ?? throw new ArgumentNullException(nameof(wait));
        this.logger = logger ?? Console.WriteLine;
    }
    public void IgnoreExceptionTypes(params Type[] exceptionTypes)
    {
        wait.IgnoreExceptionTypes(exceptionTypes);
    }
    public TResult Until<TResult>(Func<T, TResult> condition)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            return wait.Until<TResult>(condition);
        }
        finally
        {
            watch.Stop();
            logger($"Wait took: {watch.Elapsed.TotalSeconds} Seconds");
        }
    }
}
And now you can use it with *any* WebDriverWait object:
var realWait = new WebDriverWait(driver, 30);
var wait = new TimeableWebDriverWait(realWait);
wait.Until(...);
You can specify your own function to log the message, as long as it accepts a string parameter and has a `void` return type:
var realWait = new WebDriverWait(driver, 30);
var wait = new TimeableWebDriverWait(realWait, System.Diagnostic.Trace.WriteLine);
wait.Until(...);

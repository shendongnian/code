using NLog;
public class MyController : Controller
{
    private readonly Logger Logger = LogManager.GetCurrentClassLogger(); // non static because of traceid
    public MyConstructor(Apilog apilog)
    {
        Logger.SetProperty("traceid", apilog.TraceId);
    }
}
When you do share loggers between classes, or of you're not sure, then you could use WithProperty to ensure thread safeness
using NLog;
public class MyController : Controller
{
    private readonly Logger Logger; // non static because of traceid. 
    public MyConstructor(Apilog apilog)
    {
        var logger = LogManager.GetLogger("mylogger"); // Possible shared between classes. 
        Logger= logger.WithProperty("traceid", apilog.TraceId);
    }
}
> Is there some way to use SetProperty with `ILogger<MyController>`?
There is not SetProperty but you could do this:
c#
using (_logger.BeginScope(new[] { new KeyValuePair<string, object>("traceid", apilog.TraceId) }))
{
   _logger.LogDebug("Log message");
}
And use in your config: `${mdlc:traceid}`. See more details and options [here](https://github.com/NLog/NLog.Extensions.Logging/wiki/NLog-properties-with-Microsoft-Extension-Logging)

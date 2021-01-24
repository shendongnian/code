using NLog;
public class MyController : Controller
{
    private readonly Logger Logger = LogManager.GetCurrentClassLogger(); // non static because of traceid
    public MyConstructor(Apilog apilog)
    {
        Logger.SetProperty("traceid", apilog.TraceId);
    }
}
Because the logger isn't shared between classes. 
When you do share loggers between classes, you could use WithProperty to ensure thread safeness
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

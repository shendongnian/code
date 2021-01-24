public class MyClass
{
    void MyMethod()
    {
        LogTo.Debug("TheMessage");
    }
}
## What gets compiled
public class MyClass
{
    static ILogger logger = Log.ForContext<MyClass>();
    void MyMethod()
    {
        if (logger.IsEnabled(LogEventLevel.Debug))
        {
            logger
                .ForContext("MethodName", "Void MyMethod()")
                .ForContext("LineNumber", 8)
                .Debug("TheMessage");
        }
    }
}
The one potential draw-back is that you can't easily test the logging behavior of your class in unit tests, because you're not invoking an injected, mockable interface. But I've tried a lot of different approaches over the years, and this one has been by far the easiest. Besides, I've come to feel that logging is a cross-cutting concern that's kind of set apart from the normal rules of software architecture.
See https://github.com/Fody/Anotar

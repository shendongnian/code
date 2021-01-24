Log.Logger = new LoggerConfiguration()
    // Configure file sink.
    .WriteTo.RollingFile(
    new JsonPatternLayout(),
    @"c:\path\logs\app-{Date}.log",
    LogEventLevel.Information,
    retainedFileCountLimit: 90)
    .CreateLogger();
public class JsonPatternLayout : ITextFormatter
{
    public void Format(LogEvent e, TextWriter writer)
    {
        var dic = new Dictionary<string, object>
        {
            ["level"] = e.Level.ToString(),
            ["session"] = System.Threading.Thread.CurrentPrincipal.Identity.Name,
            ["timestamp"] = e.Timestamp.ToLocalTime().ToString(),
            ["message"] = e.RenderMessage(),
            ["Properties"] = e.Properties,
            ["exception"] = e.Exception == null ? string.Empty : e.Exception.ToString(),
            ["machineName"] = machineName
        };
        writer.Write($"{JsonConvert.SerializeObject(dic)}\n");
    }
}
My logging messages are formatted the same way Log4net did them, and the exceptions are not doubly logged. Was a bit of a pain to replace Log4net entirely, but went very smoothly.
Many thanks to everyone who helped and look at this.

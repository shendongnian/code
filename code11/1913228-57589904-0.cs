csharp
public class WebApiApplication : System.Web.HttpApplication
{
    protected void Application_Start()
    {
        ...
        Hierarchy hier = log4net.LogManager.GetRepository() as Hierarchy;
        var elmahIoAppender = (ElmahIoAppender)(hier?.GetAppenders())
            .FirstOrDefault(appender => appender.Name
                .Equals("ElmahIoAppender", StringComparison.InvariantCultureIgnoreCase));
        elmahIoAppender.ActivateOptions();
        elmahIoAppender.Client.Messages.OnMessage += (sender, a) =>
        {
            var ctx = HttpContext.Current;
            if (ctx == null) return;
            a.Message.Url = ctx.Request?.Path;
            a.Message.StatusCode = ctx.Response?.StatusCode;
        };
    }
}
This will cause the `OnMessage` callback to be triggered for each log message. If there's an HTTP context on the time of logging, the `Url` and `StatusCode` fields will be filled in on the message logged to elmah.io.

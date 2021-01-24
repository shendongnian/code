    public class MyFilterAttribute : ActionFilterAttribute
    {
        public LogLevel LogLevel { get; set; }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Method == HttpMethod.Get)
            {
                var log = log4net.LogManager.GetLogger(typeof(ApiController));
                if(LogLevel.Verbose)
                {
                   log.Info("This is log meassage for GET method");
                   log.Warn("This is a warn log message for a GET method");
                }
                if(LogLevel.Info)
                    log.Info("This is log meassage for GET method");
                if(LogLevel.Warning)
                     log.Warn("This is a warn log message for a GET method");
            }
        }
    }

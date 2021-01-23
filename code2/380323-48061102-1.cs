    public class WebExceptionLogger : ExceptionLogger
    {
        private const int RequestCancelledByUserExceptionCode = -2147023901;
        public override void Log(ExceptionLoggerContext context)
        {
            var dependencyScope = context.Request.GetDependencyScope();
            var loggerFactory = dependencyScope.GetService(typeof(ILoggerFactory)) as ILoggerFactory;
            if (loggerFactory == null)
            {
                throw new IoCResolutionException<ILoggerFactory>();
            }
            var logger = loggerFactory.GetTechnicalLogger<WebExceptionLogger>();
            if (context.Exception.HResult == RequestCancelledByUserExceptionCode)
            {
                logger.Info($"Request to url {context.Request.RequestUri} was cancelled by user.");
            }
            else
            {
                logger.Error("An unhandled exception has occured", context.Exception);
            }
        }
    }

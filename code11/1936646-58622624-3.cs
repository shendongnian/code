       public class LogHttpRequestAttribute : ActionFilterAttribute
       {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
    
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
           _logger.Info("action execution started");
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            _logger.Info("action execution finished");
       }

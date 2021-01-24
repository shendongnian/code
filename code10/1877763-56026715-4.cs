    public class LogParamsFilter : ActionFilterAttribute
    {
        private readonly ILogger<LogsParamsFilter> _logger;
 
        public LogParamsFilter (ILogger<LogsParamsFilter> logger)
        {
            _logger = logger;
        }
 
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var id = (int)context.ActionArguments["id"];
            var request = context.ActionArguments["request"] as RequestModel;
            var action = context.ActionDescriptor.DisplayName;
            string log = $"{action)}(id: {id}, request: {request?.ToJson()})";
            _logger.LogInformation(log);
 
            base.OnActionExecuting(context);
        }
    }

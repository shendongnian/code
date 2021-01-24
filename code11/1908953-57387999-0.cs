        public class ValidationFilter: ActionFilterAttribute
        {
         private readonly ILogger _logger;
        public ValidationFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("ValidatePayloadTypeFilter");
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var carDto = context.ActionArguments["car"] as Car;
            var id = context.ActionArguments["id"];
            if (Convert.ToInt32(id)!=carDto.Id)
            {
                context.HttpContext.Response.StatusCode = 400;
                context.Result = new ContentResult()
                {
                    Content = "Id mismatch!"
                };
                return;
            }
            
            base.OnActionExecuting(context);
         }
        }
   

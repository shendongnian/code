    public class MyValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.ActionArguments.ContainsKey("from") && context.ActionArguments.ContainsKey("to"))
            {
                var dateFrom = (DateTime)context.ActionArguments["from"];
                var dateTo = (DateTime)context.ActionArguments["to"];
                if(dateFrom <= dateTo)
                {
                    // continue the flow in pipeline
                    return;
                }
            }
            context.Result = new BadRequestResult();
        }
    }

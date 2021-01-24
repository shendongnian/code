    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var cancellationToken = context.HttpContext.RequestAborted;
            // rest of your code
        }
    }

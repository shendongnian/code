    public class MySampleActionFilter : IActionFilter
    {
        public void OnActionExecuting (ActionExecutingContext context)
        {
            // Do something before the action executes.
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
        }
    }

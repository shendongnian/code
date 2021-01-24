    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Add some condition here
            if (...)
            {
                // Execute the action if the condition is true
                await next();
            }
            else
            {
                // Short-circuit the action by specifying a result
                context.Result = new BadRequestObjectResult(new ErrorViewModel
                {
                    // ...
                });
            }
        }
    }

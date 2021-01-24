    public class VerbFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Request.Method == "HEAD")
            {
                context.Result = new StatusCodeResult(405);
            }
            else
            {
                await next();
            }
        }
    }

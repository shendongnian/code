    internal class TestAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Suggested by dropoutcoder
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.WriteAsync("You have no access").Wait();
            context.HttpContext.Response.StatusCode = 400;
            // Suggested by stuartd
            context.Result = new BadRequestObjectResult("You have no access");
        }
    }

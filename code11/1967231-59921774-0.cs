    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;
        public void OnActionExecuting(ActionExecutingContext context) { }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null) return;
            var attempt = Attempt<string>.Fail(context.Exception);
            if (context.Exception is AttemptException exception)
            {
                context.Result = new ObjectResult(attempt)
                {
                    StatusCode = exception.StatusCode,
                };
            }
            else
            {
                context.Result = new ObjectResult(attempt)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                };
            }
            context.ExceptionHandled = true;
        }
    }

    public class LogExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            //log your exception;
            context.Result = new ObjectResult("your custom message")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }

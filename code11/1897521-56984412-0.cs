    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var basePath = context.HttpContext.Request.PathBase.Value;
            context.Result = new RedirectResult($"{ basePath }/Error");
        }
    }

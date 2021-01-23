    public class HttpRequestValidationExceptionAttribute : FilterAttribute, IExceptionFilter {
        
        public void OnException(ExceptionContext filterContext) {
            if (!filterContext.ExceptionHandled && filterContext.Exception is HttpRequestValidationException) {
                filterContext.Result = new RedirectResult("~/HttpError/HttpRequestValidationError");
                filterContext.ExceptionHandled = true;
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class HandleErrorAttribute : FilterAttribute, IExceptionFilter
    {
    
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
    
            if (filterContext.ExceptionHandled)
            {
                return;
            }
    
            var exception = filterContext.Exception;
            var request = filterContext.HttpContext.Items[Request.RequestKey] as Request;
    
            if (request != null)
            {
                var errorResponse = new ErrorResponse(request, exception);
                errorResponse.Write(filterContext.HttpContext.Response);
                filterContext.ExceptionHandled = true;
            }
        }
    }

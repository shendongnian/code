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
            var request = filterContext.HttpContext.Items[Request.RequestKey] as Request; // <- that need to be your current request object. In this case I use a custom one so I must fetch it from the items collection of the current request, where I had stored it before.
    
            if (request != null)
            {
                var errorResponse = new ErrorResponse(request, exception); // <- overwrite ErrorResponse with a response object of your choice or write directly to the filterContext.HttpContext.Response
                errorResponse.Write(filterContext.HttpContext.Response);
                filterContext.ExceptionHandled = true;
            }
        }
    }

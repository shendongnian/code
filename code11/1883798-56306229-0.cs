    public class PayloadMaximumSizeFilter : ActionFilterAttribute
    {
        private long _maxContentLength;
        private string _message;
    
        public PayloadMaximumSizeFilter(long maxContentLength)
        {
            this._maxContentLength = maxContentLength;
        }
    
        public PayloadMaximumSizeFilter(long maxContentLength, string message)
        {
            this._maxContentLength = maxContentLength;
            this._message = message;
        }
    
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            long? contentLength = filterContext.HttpContext.Request.ContentLength;
            if (contentLength.HasValue && contentLength.Value > _maxContentLength)
            {
                filterContext.Result = new JsonResult(filterContext.ModelState)
                {
                    Value = _message ?? "Request body too large.",
                    StatusCode = 413
                };
            }
        }
    
    }

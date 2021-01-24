    public virtual bool AttemptResponseCaching(ResponseCachingContext context)
    {
        var request = context.HttpContext.Request;
        // Verify the method
        if (!HttpMethods.IsGet(request.Method) && !HttpMethods.IsHead(request.Method))
        {
            context.Logger.RequestMethodNotCacheable(request.Method);
            return false;
        }
        // Verify existence of authorization headers
        if (!StringValues.IsNullOrEmpty(request.Headers[HeaderNames.Authorization]))
        {
            context.Logger.RequestWithAuthorizationNotCacheable();
            return false;
        }
        return true;
    }

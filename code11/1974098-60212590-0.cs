    public override void OnActionExecuting(HttpActionContext actionContext)
    {
        HttpContext.Current.Items["Now"] = DateTime.UtcNow;
        base.OnActionExecuting(actionContext);
    }
    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
        var beginning = (DateTime) HttpContext.Current.Items["Now"];
        var end = DateTime.UtcNow;
        var interval = end - beginning;
        base.OnActionExecuted(actionExecutedContext);
    }
    

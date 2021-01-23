    protected override void Initialize(RequestContext requestContext)
    {
        base.Initialize(requestContext);
        string action = requestContext.RouteData.GetRequiredString("action");
    }
 

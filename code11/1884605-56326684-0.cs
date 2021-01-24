    public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
    {
        var configuration = routeContext.HttpContext.RequestServices.GetService<IConfiguration>();
        // do something with the configuration
    }

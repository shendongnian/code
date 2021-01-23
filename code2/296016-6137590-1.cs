    protected override void Initialize(RequestContext requestContext)
    {
        base.Initialize(requestContext);
        var url = Url.Action("UnAuthorized", "Error");
        requestContext.HttpContext.Response.Redirect(url);
    }

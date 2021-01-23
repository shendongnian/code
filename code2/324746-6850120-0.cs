    protected override void Initialize(RequestContext requestContext)
    {
        base.Initialize(requestContext);
        bool mobile = this.HttpContext.Request.Browser.IsMobileDevice; // this line errors
        if (mobile)
            master="mobile";
        else
            master="site";
    }

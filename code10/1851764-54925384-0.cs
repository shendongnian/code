    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
        base.HandleUnauthorizedRequest(filterContext);
    
        filterContext.Result = new RedirectResult(filterContext.HttpContext.Request.UrlReferrer.ToString());
    }

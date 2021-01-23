    protected override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
    {
        // Actual Authentication
        HttpContext.User = user; 
        Thread.CurrentPrincipal = user;
        base.OnAuthorization(filterContext);
    }

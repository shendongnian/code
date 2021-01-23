    protected virtual void HandleNonHttpsRequest(AuthorizationContext filterContext)
    {
        if (!string.Equals(filterContext.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(MvcResources.RequireHttpsAttribute_MustUseSsl);
        }
        string url = "https://" + filterContext.HttpContext.Request.Url.Host + filterContext.HttpContext.Request.RawUrl;
        filterContext.Result = new RedirectResult(url);
    }

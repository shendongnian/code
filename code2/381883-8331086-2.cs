    public static string ActionLink(string linkText, string actionName, string controllerName)
    {
        var httpContext = new HttpContextWrapper(System.Web.HttpContext.Current);
        var requestContext = new RequestContext(httpContext, new RouteData());
        var urlHelper = new UrlHelper(requestContext);
        return urlHelper.ActionLink(linkText, actionName, controllerName, null);
    }

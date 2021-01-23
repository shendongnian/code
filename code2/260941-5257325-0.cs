    public static string GetPageNumberLink(this HtmlHelper helper, string nameOfPageParameter, int pageNumber)
    {
           //set the placeholder
           string queryValues = helper.ViewContext.HttpContext.Request.Url.Query;
           helper.ViewContext.RouteData.Values[nameOfPageParameter] = "..PAGEHERE..";
           string virtualPath = helper.ViewContext.RouteData.Route.GetVirtualPath(helper.ViewContext.RequestContext, helper.ViewContext.RouteData.Values).VirtualPath;
    
           return helper.ResolveUrl("~/" + virtualPath.Replace("..PAGEHERE..", pageNumber.ToString())) + queryValues;
    }

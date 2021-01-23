    public static MvcHtmlString CustomLink(this HtmlHelper helper,string linktext) 
    {
        //here u can use helper to get View context and then routvalue dictionary
        var routevals = helper.ViewContext.RouteData.Values;
        //here u can do whatever u want with route values
    }

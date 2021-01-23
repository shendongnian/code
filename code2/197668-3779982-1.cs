    public static MvcHtmlString CustomLink(this HtmlHelper helper,string linktext) 
    {
        //here you can use helper to get View context and then routvalue dictionary
        var routevals = helper.ViewContext.RouteData.Values;
        //here you can do whatever you want with route values
    }

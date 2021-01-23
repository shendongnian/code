    public static IHtmlString ImageLink(
        this HtmlHelper htmlHelper,
        string imgSrc, 
        string alt, 
        string actionName,
        string controllerName, 
        object routeValues, 
        object htmlAttributes, 
        object imgHtmlAttributes
    )
    {
        return MvcHtmlString.Create(@"<img src=""../../Content/images/english.png"" />");
    }

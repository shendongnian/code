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
        var img = new TagBuilder("img");
        var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
        img.Attributes["src"] = urlHelper.Content("~/Content/images/english.png");
        // Don't forget that the alt attribute is required if you want to have valid HTML
        img.Attributes["alt"] = "English flag"; 
        return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
    }

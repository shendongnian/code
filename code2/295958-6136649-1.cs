    public static MvcHtmlString GenerateMyLink<MyViewModel>(this HtmlHelper<MyViewModel> html)
    {
        MyViewModel model = html.ViewData.Model;
        RequestContext rc = html.ViewContext.RequestContext;
        //TODO: use your view model and the HttpContext to generate whatever link is needed
        ...
    }

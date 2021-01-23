    public static MvcHtmlString CanonicalUrl(this HtmlHelper html,string host,string protocol)
    {
        var canonical = GetCanonicalUrl(HttpContext.Current.Request.RequestContext.RouteData,host,protocol);
        return new MvcHtmlString(canonical.ToString(TagRenderMode.SelfClosing));
    }
    @Html.CanonicalUrl("www.mydomain.com", "https");

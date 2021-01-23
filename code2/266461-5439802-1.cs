    public static MvcHtmlString CanonicalUrl(this HtmlHelper html)
    {
        var rawUrl = html.ViewContext.RequestContext.HttpContext.Request.Url;
    
        return CanonicalUrl(html, String.Format("{0}://{1}{2}", rawUrl.Scheme, rawUrl.Host, rawUrl.AbsolutePath));
    }

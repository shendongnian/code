    public static MvcHtmlString CanonicalUrl(this HtmlHelper html, string path)
    {
        if (String.IsNullOrWhiteSpace(path))
        {
            var rawUrl = html.ViewContext.RequestContext.HttpContext.Request.Url;
            path = String.Format("{0}://{1}{2}", rawUrl.Scheme, rawUrl.Host, rawUrl.AbsolutePath);
        }
    
        path = path.ToLower();
    
        if (path.Count(c => c == '/') > 3)
        {
            path = path.TrimEnd('/');
        }
    
        if (path.EndsWith("/index"))
        {
            path = path.Substring(0, path.Length - 6);
        }
    
        var canonical = new TagBuilder("link");
        canonical.MergeAttribute("rel", "canonical");
        canonical.MergeAttribute("href", path);
        return new MvcHtmlString(canonical.ToString(TagRenderMode.SelfClosing));
    }

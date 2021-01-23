    public static MvcHtmlString Repeater<T>(this HtmlHelper html, IEnumerable<T> items,
        Func<T, HelperResult> itemTemplate,            
        Func<string, HelperResult> containerTemplate,
        Func<string, HelperResult> emptyTemplate)
    {
        if (items == null)
            return MvcHtmlString.Create(HttpContext.Current.Server.HtmlDecode(emptyTemplate("No Results").ToHtmlString()));
        if (items.Count() == 0)
            return MvcHtmlString.Create(HttpContext.Current.Server.HtmlDecode(emptyTemplate("No Results").ToHtmlString()));
        StringBuilder sb = new StringBuilder();
        foreach (var item in items)
        {
            if (item is IEnumerable)
            {
                 sb.Append( itemTemplate( html.Repeater( (IEnumerable)item, itemTemplate, containerTemplate, emptyTemplate ) ).ToHtmlString();
            }
            else
            {
                string content = itemTemplate(item).ToHtmlString();
                sb.Append(HttpContext.Current.Server.HtmlDecode(content));
            }
        }
        return MvcHtmlString.Create(HttpContext.Current.Server.HtmlDecode(containerTemplate(sb.ToString()).ToHtmlString()));
    }

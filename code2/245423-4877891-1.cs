    using HtmlAgilityPack;
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
        var enumerableProperties = typeof(T).GetProperties()
                                            .Where( p => p is IEnumerable );
        foreach (var item in items)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml( itemTemplate(item).ToHtmlString() );
            var root = doc.DocumentNode.FirstChild;
            var insertNode = FindInsertNode( doc ); // this needs to be written        
            foreach (var property in enumerableProperties)
            {
                 var value = property.GetValue( item, null ) as IEnumerable;
                 var newNode = new HtmlNode
                               {
                                   InnerHtml = html.Repeater( value, itemTemplate, containerTemplate, emptyTemplate )
                               };
                 root.InsertAfter( newNode, insertNode );
                 insertNode = newNode;
            }
            sb.Append(html.InnerText);
        }
        return MvcHtmlString.Create(HttpContext.Current.Server.HtmlDecode(containerTemplate(sb.ToString()).ToHtmlString()));
    }

    public static IHtmlString RegisterScriptInline(this HtmlHelper htmlHelper,
        Func<object, IHtmlString> content)
    {
        string renderedContent = content.Invoice(null).ToString(); // Got it!!!
        return null;
    }

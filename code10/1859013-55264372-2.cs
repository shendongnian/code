    public static IHtmlString RegisterScriptInline(this HtmlHelper htmlHelper,
        Func<object, IHtmlString> content)
    {
        string renderedContent = content.Invoke(null).ToString(); // Got it!!!
        return null;
    }

    public static MvcHtmlString Highlight(this HtmlHelper html, string input, string searchPhrase)
    {
        var value = Regex.Replace(
            input, 
            "\\b" + searchPhrase + "\\b", 
            "<strong>" + searchPhrase + "</strong>", 
            RegexOptions.IgnoreCase
        );
        return MvcHtmlString.Create(value);
    }

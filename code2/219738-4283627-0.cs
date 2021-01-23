    public static MvcHtmlString RenderNumbers(this HtmlHelper htmlHelper, int count)
    {
        var text = string.Join(", ", Enumerable.Range(1, count).ToArray());
        return MvcHtmlString.Create(text);
    }

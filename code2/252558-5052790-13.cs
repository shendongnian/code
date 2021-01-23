    public static class ExtensionMethods
    {
        public static MvcHtmlString StateDropDownList(this HtmlHelper html)
        {
            return html.TextBox("foo")
        }
    }

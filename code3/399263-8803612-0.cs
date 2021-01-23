    public static class HtmlUrlExtension
    {
        public static string RawUrl( this HtmlHelper html, string url )
        {
             return html.Raw(HttpServerUtility.HtmlEncode(url));
        }
    }

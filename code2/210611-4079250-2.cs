    public static class CustomXpediteExtensions
    {
        private static readonly IEnumerable<String> SharedCss = new[]
        {
            "/Styles/SharedStyle1.css",
            "/Styles/SharedStyle2.css",
            "/Styles/SharedStyle3.css"
        };
        
        public static MvcHtmlString CustomCompositeCssResource(this HtmlHelper htmlHelper, params String[] resources)
        {
            return htmlHelper.CompositeCssResource(SharedCss.Concat(resources));
        }
    }

    public static class PageExtensions
    {
        public static MvcHtmlString Resource(this WebViewPage page, string key)
        {
            HttpContextBase http = page.ViewContext.HttpContext;
            string ret = (string) http.GetLocalResourceObject(page.VirtualPath, key);
            return MvcHtmlString.Create(ret);
        }
    
        public static MvcHtmlString Resource(
            this WebViewPage page, string key, 
            Dictionary<string, MvcHtmlString> tokenMap
        ) {
            HttpContextBase http = page.ViewContext.HttpContext;
            string text = (string) http.GetLocalResourceObject(page.VirtualPath, key);
            return new TagReplacer(text, tokenMap).ToMvcHtmlString();
        }
    }

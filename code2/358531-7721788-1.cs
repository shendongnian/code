    static public class MyHtmlHelpers
    {
        public static IDisposable BeginChildScope<TModel>(this HtmlHelper<TModel> html, string parentScopeName)
        {
            return new ChildPrefixScope(html.ViewData.TemplateInfo, parentScopeName);
        }
        private class ChildPrefixScope : IDisposable
        {
            private readonly TemplateInfo _templateInfo;
            private readonly string _previousPrefix;
            public ChildPrefixScope(TemplateInfo templateInfo, string collectionItemName)
            {
                this._templateInfo = templateInfo;
                _previousPrefix = templateInfo.HtmlFieldPrefix;
                templateInfo.HtmlFieldPrefix = collectionItemName;
            }
            public void Dispose()
            {
                _templateInfo.HtmlFieldPrefix = _previousPrefix;
            }
        }
    }

    public override void OnResultExecuting(ResultExecutingContext filterContext) {
        if (filterContext == null) {
            throw new ArgumentNullException("filterContext");
        }
        // we need to call ProcessRequest() since there's no other way to set the Page.Response intrinsic
        OutputCachedPage page = new OutputCachedPage(_cacheSettings);
        page.ProcessRequest(HttpContext.Current);
    }
    private sealed class OutputCachedPage : Page {
        private OutputCacheParameters _cacheSettings;
        public OutputCachedPage(OutputCacheParameters cacheSettings) {
            // Tracing requires Page IDs to be unique.
            ID = Guid.NewGuid().ToString();
            _cacheSettings = cacheSettings;
        }
        protected override void FrameworkInitialize() {
            // when you put the <%@ OutputCache %> directive on a page, the generated code calls InitOutputCache() from here
            base.FrameworkInitialize();
            InitOutputCache(_cacheSettings);
        }
    }

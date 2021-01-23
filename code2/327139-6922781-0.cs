        private readonly HttpContextBase _httpContextBase;
        public HttpContextCache()
        {
            _httpContextBase = new HttpContextWrapper(HttpContext.Current);
        }
        public HttpContextCache(HttpContextBase httpContextBase)
        {
            _httpContextBase = httpContextBase;
        }

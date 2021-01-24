        private readonly IMemoryCache _cache;
        public ProductConstraint(IMemoryCache cache)
        {
            _cache = cache;
        }
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (_cache.Get("URLProductListCache") == null)
            {
                var cacheEntry = _cache.CreateEntry("URLProductListCache");
                var _context = (ApplicationDbContext)httpContext.RequestServices.GetService(typeof(ApplicationDbContext));
                var url = _context.Product.AsNoTracking().Select(c => c.URL).ToList();
                cacheEntry.SetValue(url);
                cacheEntry.Dispose();
                return url.Contains(values[routeKey]?.ToString().ToLowerInvariant());
            }
            else
            {
                var url = _cache.Get("URLProductListCache") as List<string>;
                return url.Contains(values[routeKey]?.ToString().ToLowerInvariant());
            }
        }
 

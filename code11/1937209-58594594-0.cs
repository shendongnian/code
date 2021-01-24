    public class HomeController : Controller
    {
        private IMemoryCache _cache;
    
        public HomeController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }    
    
        public async Task<IActionResult> CacheGetOrCreateAsynchronous()
        {
            string cacheKey = $"{HttpContext.Session.Id}_data";
            var cacheEntry = await
                _cache.GetOrCreateAsync(cacheKey , entry =>
                {
                    entry.SlidingExpiration = TimeSpan.FromSeconds(3);
                    return Task.FromResult(DateTime.Now);
                });
        
            return View("Cache", cacheEntry);
        }
    }

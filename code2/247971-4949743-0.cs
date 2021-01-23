    public ActionResult Index()
        {
            string key = "Hello";
            string value = "World";
            var cache = MemoryCache.Default;
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddDays(1);
            cache.Add(new CacheItem(key, value), policy);
            cache.Add(new CacheItem(key + "Policy", policy), null);
            CacheItem item = cache.GetCacheItem(key);
            CacheItem policyItem = cache.GetCacheItem(key + "Policy");
            CacheItemPolicy policy2 = policyItem.Value as CacheItemPolicy;
            ViewBag.Message = key + " " + value;
            return View();
        }
 

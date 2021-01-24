public void ConfigureServices(IServiceCollection services)
{
    services.AddMemoryCache();
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
}
...ask for it in a constructor...
private IMemoryCache _cache;
public HomeController(IMemoryCache memoryCache)
{
    _cache = memoryCache;
}
...and use it...
public IActionResult CacheTryGetValueSet()
{
    DateTime cacheEntry;
    // Look for cache key.
    if (!_cache.TryGetValue(CacheKeys.Entry, out cacheEntry))
    {
        // Key not in cache, so get data.
        cacheEntry = DateTime.Now;
        // Set cache options.
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            // Keep in cache for this time, reset time if accessed.
            .SetSlidingExpiration(TimeSpan.FromSeconds(3));
        // Save data in cache.
        _cache.Set(CacheKeys.Entry, cacheEntry, cacheEntryOptions);
    }
    return View("Cache", cacheEntry);
}
Read Microsoft's [Cache in-memory in ASP.NET Core][1] for more details. All of the above code comes from that page.
---
As for the concern "well what if my cache doesn't have the value at the moment I ask for it".
Uh, welcome to multi-threaded code. This is just fact of life, cache-misses are a thing. It's going to be """"more""" reliable because the whole cycle is in memory, but you still need to take it into consideration.
[1]: https://docs.microsoft.com/en-us/aspnet/core/performance/caching/memory?view=aspnetcore-2.2

    // Example middleware
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Caching.Memory;
    
    namespace YourNamespaceHere
    {
        public class MySingleRequestLimitingMiddleware
        {
            private readonly RequestDelegate _next;
            private readonly IMemoryCache _cache;
            private readonly string FlagCacheKey = "RequestAvailability";
            private readonly string _statusLocked = "locked";
            private readonly string _statusAvailable = "available";
    
            public MySingleRequestLimitingMiddleware(RequestDelegate next,
                IMemoryCache cache)
            {
                _next = next;
                _cache = cache;
            }
    
            public async Task Invoke(HttpContext httpContext)
            {
                string cacheEntry;
    
                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for 2 minutes.
                    .SetAbsoluteExpiration(DateTimeOffset.Now.AddMinutes(2));
    
                // Look for the cache key.
                if (!_cache.TryGetValue(FlagCacheKey, out cacheEntry))
                {
                    // Key not in cache, so set lock.
                    cacheEntry = _statusAvailable;
    
                    // Save data in cache.
                    _cache.Set(FlagCacheKey, cacheEntry, cacheEntryOptions);
                }
    
                if (cacheEntry.Equals(_statusLocked, StringComparison.OrdinalIgnoreCase))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    httpContext.Response.ContentType = "text/plain";
    
                    await httpContext.Response.WriteAsync("Maximum API calls admitted: 1.");
    
                    return;
                }
    
                /* ***BEWARE: You are entering the request the next line
                 * will lock up your entire service until this flag is changed.
                 * You must set the flag in your controller or somewhere else every single
                 * request no fail or your service will be left in an unusable state.
                 * The only thing that fixes the state if you fail to change state
                 * is restarting the service or waiting 2 minutes. */
                _cache.Set(FlagCacheKey, _statusLocked, cacheEntryOptions);
    
                await _next.Invoke(httpContext);
            }
        }
    }
    
    // In your Startup.cs
    namespace YourNamespaceHere
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMemoryCache(); // Add this line to yours somewhere
            }
    
            public void Configure(IApplicationBuilder app)
            {
                // Put it at very top because you don't need to run anything
                // else if the limit of 1 request has already been reached.
                app.UseWhen(context => context.Request.Path.StartsWithSegments("/somepathtoyourcallhere"), appBuilder =>
                {
                    appBuilder.UseMySingleRequestLimitingMiddleware();
                });
    
                // The rest of your code
            }
        }
    }
    
    // Example Controller
    // In the controller containing your singleton request call
    // ***NOTE you MUST set the flag even if there is an error!!!
    public class SomeController : Controller
    {
        private IMemoryCache _cache;
    
        public SomeController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
    
        [HttpPost]
        public IActionResult YourSingleServiceRequestActionNameHere(SomeMode model)
        {
            // Some code here...
            _cache.Set(FlagCacheKey, "available", new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTimeOffset.Now.AddMinutes(2)));
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Just in case you didn't set that flag already lets make sure.
                _cache.Set(FlagCacheKey, "available", new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTimeOffset.Now.AddMinutes(2)));
            }
    
            base.Dispose(disposing);
        }
    }

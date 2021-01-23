    public class OutputCache : ActionFilterAttribute
    {
    public int Duration { get; set; }
    public CachePolicy CachePolicy { get; set; }
    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        // Client-side caching?
        if (CachePolicy == CachePolicy.Client || CachePolicy == CachePolicy.ClientAndServer)
        {
            if (Duration <= 0) return;
            HttpCachePolicyBase cache = filterContext.HttpContext.Response.Cache;
            TimeSpan cacheDuration = TimeSpan.FromSeconds(Duration);
            cache.SetCacheability(HttpCacheability.Public);
            cache.SetExpires(DateTime.Now.Add(cacheDuration));
            cache.SetMaxAge(cacheDuration);
            cache.AppendCacheExtension("must-revalidate, proxy-revalidate");
        }
    }
    }

    using System;
    using System.Web;
    using System.Web.Mvc;
    
        public class CacheFilterAttribute : ActionFilterAttribute
        {
    
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                HttpCachePolicyBase cache = filterContext.HttpContext.Response.Cache;
                
                cache.SetExpires(DateTime.UtcNow.AddDays(-1));
                cache.SetValidUntilExpires(false);
                cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                cache.SetCacheability(HttpCacheability.NoCache);
                cache.SetNoStore();
            }
        }

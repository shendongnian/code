    public class AuthorizeWithThrottleAttribute : AuthorizeAttribute
    {
        private class Attempts
        {
            public int NumberOfAccess { get; set; }
        }
        public int Seconds { get; private set; }
        public int Count { get; private set; }
        public AuthorizeWithThrottleAttribute(int seconds, int count)
        {
            Seconds = seconds;
            Count = count;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                return false;
            }
            var rd = httpContext.Request.RequestContext.RouteData;
            var action = rd.GetRequiredString("action");
            var controller = rd.GetRequiredString("controller");
            // Remark: if you are using areas maybe you could also want
            // to constrain the key per area
            var key = string.Format("throttle-{0}-{1}-{2}", httpContext.User.Identity.Name, controller, action);
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(Seconds),
            };
            // Here we are using the new caching API introduced in .NET 4.0:
            // http://msdn.microsoft.com/en-us/library/system.runtime.caching.aspx
            // If you are using an older version of the framework you could use
            // the legacy HttpContext.Cache instead which offers the same expiration
            // policy features as the new
            var attempts = MemoryCache.Default.Get(key) as Attempts;
            if (attempts == null)
            {
                attempts = new Attempts();
                MemoryCache.Default.Set(key, attempts, policy);
            }
            if (attempts.NumberOfAccess < Count)
            {
                attempts.NumberOfAccess++;
                return true;
            }
            httpContext.Items["throttled"] = true;
            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var throttled = filterContext.HttpContext.Items["throttled"];
            if (throttled != null && (bool)throttled)
            {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                filterContext.Result = new ContentResult
                {
                    Content = string.Format("You may only call this action {0} times every {1} seconds", Count, Seconds),
                    ContentType = "text/plain"
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }

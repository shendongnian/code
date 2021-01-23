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
            var key = string.Format("throttle-{0}-{1}-{2}", httpContext.User.Identity.Name, controller, action);
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(Seconds),
            };
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
            var throttled = (bool)filterContext.HttpContext.Items["throttled"];
            if (throttled)
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

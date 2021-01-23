    public class MvcApplication : System.Web.HttpApplication
    {
        public override void Init()
        {
            base.Init();
            this.AuthenticateRequest += new EventHandler(MvcApplication_AuthenticateRequest);
        }
        void MvcApplication_AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                var name = HttpContext.Current.User.Identity.Name;
                var key = "User-" + name;
                var principal = HttpContext.Current.Cache["User-" + name];
                if (principal == null)
                {
                    principal = GetYourUserAsIPrincipal();
                    // Add to cache for 1 hour with sliding expiration
                    HttpContext.Current.Cache.Insert(key, principal, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0));
                }
                HttpContext.Current.User = principal ;
            }
        }        
    }

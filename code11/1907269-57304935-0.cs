    public class RequestLifetimeCache : RequestLifetimeCacheBase
    {
    
        public RequestLifetimeCache(HttpContextBase ctx) : base(ctx)
        {
        }
        public RequestLifetimeCache(Controller controller) : base(controller)
        {
        }
    
        public WebsiteDatabaseContext CustomerDatabase
        {
            get
            {
                return base.GetCachedObject<WebsiteDatabaseContext>("Customer database");
            }
    
        }
    }

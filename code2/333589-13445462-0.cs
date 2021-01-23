    public class SmartController : Controller
    {
        ...
        public HttpContextBase Context { get; set; }
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            Context = requestContext.HttpContext;
            if (Context.Request.RequestType != "GET")
            {
                Context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            }
            base.Initialize(requestContext);
            ...
        }
    ...
    }

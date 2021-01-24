    public class MvcApplication : System.Web.HttpApplication
    {
        public static HttpClient HttpClient { get; set; }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            HttpClient = new HttpClient();
        }
        protected void Application_End()
        {
            if (HttpClient == null) return;
            HttpClient.Dispose();
        }
    }

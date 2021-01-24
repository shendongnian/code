    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            PostInitializer.Seed(); // <-- Here it is
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }

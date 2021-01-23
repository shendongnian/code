    public static void RegisterRoutes(RouteCollection routes) {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
         routes.MapRoute(
                    "Default", // Route name
                    "{controller}/{action}/{*catchall}", // URL with parameters
                    new { controller = "Home", action = "Index" } // Parameter defaults
                );
    }
    protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            ValueProviderFactories.Factories.Add(new KeyValuePairValueProviderFactory());
        }

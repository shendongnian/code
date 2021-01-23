        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            // ** comment out ** WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            new ProteinTrackerAppHost().Init();
        }

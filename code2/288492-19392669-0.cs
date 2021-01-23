        protected void Application_Start()
        {
            HttpContext.Current.Application["UnityContainer"] = System.Web.Mvc.DependencyResolver.Current.GetService(typeof(EFUnitOfWork));
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }

    public class MvcApplication : Ninject.Web.Mvc.NinjectHttpApplication
    {
        private class MyModule : NinjectModule
        {
            public override void Load()
            {
                Bind<IService>().To<ServiceImpl>();
                Bind<IAuthenticationHelper>().To<AuthenticationHelperImpl>();
            }
        }
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
        protected override IKernel CreateKernel()
        {
            var modules = new INinjectModule[] {
                new MyModule()
            };
            var kernel = new StandardKernel(modules);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            return kernel;        
        }
    }

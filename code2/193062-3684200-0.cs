    public class MvcApplication : NinjectHttpApplication
    {
        public MvcApplication()
        {
            NHibernateProfiler.Initialize();
            EndRequest += delegate { NHibernateHelper.EndContextSession(Kernel.Get<ISessionFactory>()); };            
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
                );
        }
        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }   
        protected override IKernel CreateKernel()
        {
            StandardKernel kernel = new StandardKernel();
            kernel.Load(AppDomain.CurrentDomain.GetAssemblies());            
            return kernel;
        }
    }

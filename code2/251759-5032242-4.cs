    public class MvcApplication : NinjectHttpApplication
    {
        public override void Init()
        {
            base.Init();
            Mappers.Initialize();
        }
        protected override Ninject.IKernel CreateKernel()
        {
            return Ioc.Initialize();
        }
        protected override void OnApplicationStarted()
        {
			AreaRegistration.RegisterAllAreas();
			RegisterRoutes(RouteTable.Routes);
        }
        public static void RegisterRoutes(RouteCollection routes) 
        {
			Routing.RegisterRoutes(routes);
			//RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
		}
    }

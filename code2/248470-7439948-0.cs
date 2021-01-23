    [ModuleExport(typeof(HelloWorldModule))]
    public class HelloWorldModule : IModule
    {
        [Import]
        private IRegionManager regionManager;
        public void Initialize()
        {
            Uri viewNav = new Uri("HelloWorldView", UriKind.Relative);
            regionManager.RequestNavigate("PrimaryRegion", viewNav);
        }
    }

        [ModuleExport(typeof(HelloWorldModule), InitializationMode = InitializationMode.OnDemand)]
    public class HelloWorldModule : IModule
    {
        private IRegionManager regionManager;      
        [ImportingConstructor]
        public HelloWorldModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        } 
        
        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion("PrimaryRegion", typeof(Views.HelloWorldView));
        }
    }

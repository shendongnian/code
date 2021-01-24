    public class Bootstrapper : IModule
    {
         public void OnInitialized(IContainerProvider containerProvider)
         {
            _regionManager.RegisterViewWithRegion("RegionName", typeof(View));
            _regionManager.RegisterViewWithRegion("RegionName", typeof(View2));
         }
    }

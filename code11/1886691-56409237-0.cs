    public class MyApplication : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Login>();
        }
    }
	internal class MainWindowViewModel
	{
		public MainWindowViewModel( IRegionManager regionManager )
		{
			regionManager.RequestNavigate( "ContentRegion", "Login" );
		}
	}

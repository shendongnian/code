    public class MainWindowViewModel : BindableBase
        {
            private readonly IUnityContainer _container;
            private readonly IRegionManager _regionManager;
            private PrismApplication _application;
            //private string _title = "Prism Application";
            //public string Title
            //{
            //    get { return _title; }
            //    set { SetProperty(ref _title, value); }
            //}
    
            public MainWindowViewModel(IUnityContainer container, IRegionManager regionManager)
            {
                _container = container;
                _regionManager = regionManager;
            }
        }

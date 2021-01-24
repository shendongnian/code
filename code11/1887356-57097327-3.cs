    class LoginViewModel : BindableBase
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private PrismApplication _application;
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public DelegateCommand LoginCommand { get; set; }
        public delegate void NewWindowDelegate(Object win);
        public delegate void CloseWindowDelegate();
        public CloseWindowDelegate CloseWindow{ get; set; }
        public NewWindowDelegate NewWindow { get; set; }
        public LoginViewModel(IUnityContainer container, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _container = container;
            LoginCommand = new DelegateCommand(OnLogin);
        }
        private void OnLogin()
        {
            Trace.WriteLine("Logging in");
            // do your login stuff
            // If Login OK continue here
            NewWindow.Invoke(_container.Resolve<MainWindow>());
            CloseWindow.Invoke();
        }
    }

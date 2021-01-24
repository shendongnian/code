    public partial class MainWindow : Window
    {
        private readonly Func<ViewA> _viewAFactory;
        private readonly Func<ViewB> _viewABFactory;
        IRegionManager _regionManager;
        IRegion _region;
        ViewA _viewA;
        ViewB _viewB;
        public MainWindow(Func<ViewA> viewAFactory, Func<ViewB> viewBFactory, IRegionManager regionManager)
        {
            InitializeComponent();
            _viewAFactory = viewAFactory;
            _viewBFactory = viewBFactory;
            _regionManager = regionManager;
            this.Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
                _viewA = _viewAFactory();
                _viewB = _viewBFactory();
                _region = _regionManager.Regions["ContentRegion"];
                _region.Add(_viewB);
                _region.Add(_viewA);
        }
    }

    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;
        public MainWindow()
        {
            _viewModel = new MainWindowViewModel();
            _viewModel.MyPeeps = new People();
            _viewModel.MyPeeps.Add(new Person("Fred"));
            _viewModel.MyPeeps.Add(new Person("Jack"));
            _viewModel.MyPeeps.Add(new Person("Jill"));
            DataContext = _viewModel;
            InitializeComponent();
        }
    }

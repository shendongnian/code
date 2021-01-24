       public partial class MainWindow : Window
    {
        private readonly ViewModel viewModel = new ViewModel();
        public MainWindow()
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }

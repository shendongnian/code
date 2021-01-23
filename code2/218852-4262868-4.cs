    namespace INotifyChangedDemo
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private MainViewModel _viewModel = new MainViewModel();
    
            public MainWindow()
            {
                InitializeComponent();
                DataContext = _viewModel;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                _viewModel.HitCount = _viewModel.HitCount + 1;
            }
        }
    }

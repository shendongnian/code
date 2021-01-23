    public partial class MainWindow : Window
    {
        List<string> list1 = new List<string>() { "list 1", "list 1", "list 1" };
        List<string> list2 = new List<string>() { "list 2", "list 2", "list 2" };
        ComboBoxViewModel viewModel = new ComboBoxViewModel();
    
        public MainWindow()
        {
            InitializeComponent();
            cb_Test.DataContext = viewModel;
        }
    
        private void radioButton1_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ItemsSource = list1;
            viewModel.SelectedIndex = 0;
        }
    
        private void radioButton2_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ItemsSource = list2;
            viewModel.SelectedIndex = 0;
        }
    }

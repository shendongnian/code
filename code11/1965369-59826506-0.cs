    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            MyFooCollection = Enumerable.Range(1, 10).ToList();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyFooComboBox.SelectedIndex = -1;
        }
    }

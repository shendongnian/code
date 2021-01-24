    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TxtDisplay.Visibility = Visibility.Visible;
        }
        private void Button_LostFocus(object sender, RoutedEventArgs e)
        {
            TxtDisplay.Visibility = Visibility.Hidden;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GridMain.Focus();
        }
    }

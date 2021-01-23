    public partial class MainWindow : Window
    {
        NavigationWindow winWait;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnShow(object sender, RoutedEventArgs e)
        {
            if (winWait != null) return; 
            winWait = new NavigationWindow();
            winWait.Content = new PageWait();
            winWait.Show();
        }
        private void btnHide(object sender, RoutedEventArgs e)
        {
            if (winWait != null) winWait.Close();
        }
    }

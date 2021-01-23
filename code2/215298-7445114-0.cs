    public partial class MainWindow
    {
        private SomeCustomWindow _someCustomWindow;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnOpenCustomWindowButtonClick(object sender, RoutedEventArgs e)
        {
            if (_someCustomWindow != null)
                _someCustomWindow.Close();
            _someCustomWindow = new SomeCustomWindow();
        
            _someCustomWindow.ShowDialog();
        }
        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (_someCustomWindow!= null)
                _someCustomWindow.Close();
        }
    }

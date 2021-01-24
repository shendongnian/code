    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            ((LoginViewModel)DataContext).NewWindow += StartMainApp;
            ((LoginViewModel)DataContext).CloseWindow += CloseWindow;
        }
        private void StartMainApp(Object win)
        {
            Application.Current.MainWindow = (Window)win;
            Application.Current.MainWindow.Show();
        }
        private void CloseWindow()
        {
            this.Close();
        }
    }

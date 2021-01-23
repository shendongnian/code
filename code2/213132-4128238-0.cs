    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ShowChildWindow()
        {
            MyChildWindow window = new MyChildWindow();
            window.Owner = this; // Set owner of child window.
            window.Show();
        }
    }

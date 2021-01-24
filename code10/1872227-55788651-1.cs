     public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                MainWindowVM DC = new MainWindowVM();
                DC.Init();
                this.DataContext = DC;
            }
        }

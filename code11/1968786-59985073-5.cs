    public partial class MainWindow : Window
    {
        private UserViewModel userViewModel = new UserViewModel();
    
    
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this.userViewModel;
        }
    }

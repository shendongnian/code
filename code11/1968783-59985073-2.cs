    public partial class MainWindow : Window
    {
        UserViewModel userViewModel = new UserViewModel();
    
    
        public MainWindow()
        {
            InitializeComponent();
            DataContext = userViewModel;
        }
    }

    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
    
            this.DataContext = new MainPageViewModel();
        }
    }

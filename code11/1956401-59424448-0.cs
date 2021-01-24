    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
    
            Page initialPage;
    
            if (false) // check if logged in
            {
                initialPage = new LoginPage();
            }
            else
            {
                initialPage = new MainPage();
            }
    
            MainPage = initialPage;
        }
    }

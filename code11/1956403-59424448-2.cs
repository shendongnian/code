    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage(false);
        }
    }
    public class MainPage : MasterDetailPage
    {
        public MainPage(bool value)
        {
            Master = new MasterPage();
            Detail = value ? new NavigationPage(new LoginPage()) : new NavigationPage(new DummyPage());
        }
    }

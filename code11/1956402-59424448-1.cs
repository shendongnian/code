    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }
    }
    public class MainPage : MasterDetailPage
    {
        public MainPage(bool value)
        {
            Master = new MasterPage();
            Detail = value ? new NavigationPage(new LoginPAge()) : new NavigationPage(new DummyPage());
        }
    }

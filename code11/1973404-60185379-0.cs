public class App : Application
{
    public App()
    {
        InitializeComponent();
    }
    protected override async void OnStart()
    {
        // show the splash
        MainPage = new SplashPage();
        // simple wait or initialize some services
        await Task.Delay(2000); 
        // show the real page
        MainPage = new NavigationPage(new TabbedPageContainer()); 
    }
}

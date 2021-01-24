public partial class App : Application
{
    public App()
    {
        InitializeComponent();
      
        if (false) // check if logged in
        {       
           MainPage = new NavigationPage(initialPage);
        }
        else
        {
            MainPage = new MainPage();
        }  
    }
}

public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var thePage = FreshPageModelResolver.ResolvePageModel<LogInViewModel>();
            MainPage = new FreshNavigationContainer(thePage);
        }
}
I didn't say this on the question, but the purpose of all of this was to not see a bar at the top of the screen, which now I understand that because a navigation page and a content page are not 2 different things, you can do it in the page.xaml with:
<ContentPage NavigationPage.HasNavigationBar="False">

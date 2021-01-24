    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            
            App.Current.Properties["isLogin"] = true;
            App.Current.SavePropertiesAsync();
            TabbedPage p = App.Current.MainPage as TabbedPage;
            var navigationPage = new NavigationPage(new AccoutPage());
            navigationPage.IconImageSource = "tab_accout.png";
            navigationPage.Title = "Accout";
            p.Children.Add(navigationPage);
            p.Children.RemoveAt(2);
            p.CurrentPage = navigationPage;
        }
    }

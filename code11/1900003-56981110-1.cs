    namespace TestApp
    {
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class HomePage : ContentPage
        {
            HomePageViewModel homePageViewModel = new HomePageViewModel();
            public HomePage()
            {
                InitializeComponent();
    
                BindingContext = homePageViewModel ;
            }
    
            private void ToolbarItem_Clicked(object sender, EventArgs e)
            {
                homePageViewModel.CurrentDay = xxx ;
    
                homePageViewModel.xxxxx = xxxx;
                //Something like this can change model data
            }
        }
    }

    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (CrossConnectivity.Current.IsConnected) {  
                Broswer.Source = "https://mywebpage.com/"; 
            } else {  
                DisplayAlert ("Alert", "Your alert", "OK");  
            } 
        }
        protected override bool OnBackButtonPressed()
        {
            if (Broswer.CanGoBack)
            {
                Broswer.GoBack();
                return true;
            }
            return false;
        }
    }

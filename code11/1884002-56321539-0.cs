    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    
        protected override async void OnAppearing()
        {
            base.OnAppearing();
    
            bool a = await GetPermissions();
        }
    
        public static async Task<bool> GetPermissions()
        {
            ....
        }
    }

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }
        protected override async void OnStart()
        {
            namespace.MainPage main = await namespace.MainPage.CreateMainPageAsync();
            MainPage = main;
        }
    }

    public sealed partial class MainPage : Page
    {
        public AppViewModel ViewModel { get; set; } = new AppViewModel();
        public static MainPage Current;
        // The "Current" property is necessary in order to retriew the singleton istance of the AppViewModel in the entire app... thus we are using the MainPage as a "shell" structure for the app
        public MainPage()
        {
            Current = this;
            // Other things...
        }
        // Other stuff...
    }

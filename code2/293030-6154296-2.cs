    public partial class App : Application
    {
        public static Dispatcher Dispatcher { get; private set; } // Add this line!!
        // More code follows we're skipping it
        
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this.RootVisual = new MainPage(); 
            Dispatcher = this.RootVisual.Dispatcher; // only add this line!!
        }
        private void Application_Exit(object sender, EventArgs e)
        {
            // Do this to clean up
            Dispatcher = null;
        }
    }

    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var w = new YourDisclosureWindowClass();
            w.ShowDialog();
            // whatever you need to run you entire application
        }
    }

    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (ConditionIsMet)
            {
                var window = new MainWindow();
                window.Show();
            }
            else
            {
                this.Shutdown();
            }
        }
    }

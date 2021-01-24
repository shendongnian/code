    public partial class App : Application
    {
        public App()
        {
            Startup += App_Startup;
        }
        private async void App_Startup( object sender, StartupEventArgs e )
        {
            var splash = new SplashWindow();
            splash.Show();
            
            await InitializeAsync();
            var main = new MainWindow();
            main.Show();
            MainWindow = main;
            splash.Close();            
        }
        private Task InitializeAsync()
        {
            // Do some ASYNC initialization 
            return Task.Delay( 5000 );
        }
    }

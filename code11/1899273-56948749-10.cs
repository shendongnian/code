    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.ConfigureContainerBuilder();
            Application.Current.MainWindow = container.Resolve<MainWindow>();
            Application.Current.MainWindow.Show();         
        }
    }

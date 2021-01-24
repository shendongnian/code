    public partial class App : PrismApplication
    { 
        protected override Window CreateShell()
        {
            return Container.Resolve<Login>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register(typeof(object), typeof(Login), "Login");
            containerRegistry.RegisterInstance(typeof(LoginViewModel), new LoginViewModel(Container.GetContainer(), Container.Resolve<RegionManager>()));
            containerRegistry.Register(typeof(object), typeof(MainWindow), "MainWindow");
            containerRegistry.RegisterInstance(typeof(MainWindowViewModel), new MainWindowViewModel(Container.GetContainer(), Container.Resolve<RegionManager>()));
        }
    }

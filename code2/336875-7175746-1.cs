    public class Bootstrapper : UnityBootstrapper
        {
            protected override void ConfigureContainer()
            {
                base.ConfigureContainer();
                var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                section.Configure(Container);
                
               // initialize some services before
                App.CloseSplashScreen(0);
            }
    
            protected override IModuleEnumerator GetModuleEnumerator()
            {
                return new ExtendedConfigurationModuleEnumerator();
            }
         
            protected override DependencyObject CreateShell()
            {
                MainWindow shell = new MainWindow(Container);
                shell.Show();
                return shell;
            }
        }

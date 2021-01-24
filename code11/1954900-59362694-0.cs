    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private async void Application_Startup(object sender, StartupEventArgs e)
        {           
            ILogger log = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(path: logFolder, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
                .CreateLogger();
            var ioc = new WindsorContainer();
			
            ioc.Register(Castle.MicroKernel.Registration.Component.For<ILogger>().Instance(log));
            ioc.Register(Castle.MicroKernel.Registration.Component.For<SomeDependency...>().ImplementedBy<SomeDependency Implementation...>());
			ioc.Register(Castle.MicroKernel.Registration.Component.For<SomeDependency...>().ImplementedBy<SomeDependency Implementation...>());
			
			ioc.Register(Castle.MicroKernel.Registration.Component.For<MainWindow>().ImplementedBy<MainWindow>());
			//... etc.
            var window = ioc.Resolve<MainWindow>();
            window.Show();
        }
    }

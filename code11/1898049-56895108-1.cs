    public partial class App : Application {
        DryIoc.Container container;
    
        private void Application_Startup(object sender, StartupEventArgs e) {
            container = RegisterIoc();    
            var mainwindow = container.Resolve<MainWindow>(); 
            mainwindow.Show();
        }
    
        private DryIoc.Container RegisterIoc() {
            var container = new DryIoc.Container();
            container.Register<MainWindow>();
            container.Register<Window2>();
            container.Register<IManager1, Manager1>(Reuse.Singleton);
            container.Register<IManager2, Manager2>(Reuse.Singleton);
            container.Register<IManager3, Manager3>(Reuse.Singleton);
            return container;
        }
    }

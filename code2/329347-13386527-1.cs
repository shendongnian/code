        public partial class App : Application
        {
            public App()
            {
                IDisposable disposableViewModel = null;
                //Create and show window while storing datacontext
                this.Startup += (sender, args) =>
                {
                    MainWindow = new MainWindow();
                    disposableViewModel = MainWindow.DataContext as IDisposable;
                    MainWindow.Show();
                };
                
                //Dispose on unhandled exception
                this.DispatcherUnhandledException += (sender, args) => 
                { 
                    if (disposableViewModel != null) disposableViewModel.Dispose(); 
                };
                //Dispose on exit
                this.Exit += (sender, args) =>
                { 
                    if (disposableViewModel != null) disposableViewModel.Dispose(); 
                };
            }
        }

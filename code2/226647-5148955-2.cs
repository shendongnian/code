         public class EntryPoint
        {
            [STAThread]
            public static void Main(string[] args)
            {
                SingleInstanceManager manager = new SingleInstanceManager();
                manager.Run(args);
            }
        }
    
        public class SingleInstanceManager : WindowsFormsApplicationBase
        {
            SingleInstanceApplication app;
    
            public SingleInstanceManager()
            {
                this.IsSingleInstance = true;
            }
    
            protected override bool OnStartup(Microsoft.VisualBasic.ApplicationServices.StartupEventArgs e)
            {
                app = new SingleInstanceApplication();
                app.Run();
                return false;
            }
    
            protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
            {
                base.OnStartupNextInstance(eventArgs);
                app.Activate();
            }
        }
    
        public class SingleInstanceApplication : Application
        {
            protected override void OnStartup(System.Windows.StartupEventArgs e)
            {
                base.OnStartup(e);
              
                bool startMinimized = false;
                for (int i = 0; i != e.Args.Length; ++i)
                {
                    if (e.Args[i] == "/StartMinimized")
                    {
                        startMinimized = true;
                    }
                }
    
                MainWindow mainWindow = new MainWindow();
                if (startMinimized)
                {
                    mainWindow.WindowState = WindowState.Minimized;
                }
                mainWindow.Show();
            }
        
    
            public void Activate()
            {
                this.MainWindow.Activate();
                this.MainWindow.WindowState = WindowState.Normal;
            }
        }
    }

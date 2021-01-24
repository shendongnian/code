    public partial class App : Application
        {
            App()
            {
                InitializeComponent();
            }
    
            [STAThread]
            static void Main()
            {
                SingleInstanceManager manager = new SingleInstanceManager();
                //manager.Run(new[] { "test" });
                manager.Run(Environment.GetCommandLineArgs());
    
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
            // First time app is launched
            app = new SingleInstanceApplication();
            app.Run();
            return false;
        }
    
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            // Subsequent launches
            base.OnStartupNextInstance(eventArgs);
            //MessageBox.Show("Event arguments:"+ eventArgs.ToString());            
            app.Activate(eventArgs.CommandLine.ToArray<string>());
        }
    }
    
    public class SingleInstanceApplication : Application
    {
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            base.OnStartup(e);
    
            // Create and show the application's main window
            MainWindow window = new MainWindow();
            window.Show();
        }
    
        public void Activate(string[] eventArgs)
        {
    
            ((MainWindow)this.MainWindow).SpracujCommandLineArgs(eventArgs);
            this.MainWindow.WindowState = WindowState.Maximized;            
            this.MainWindow.Activate();             
    
        }
    }

    static class Program
    {
        [STAThread]
        static void Main(params string[] Arguments)
        {
            SingleInstanceApplication.Run(new ControlPanel(), NewInstanceHandler);
        }
        
        public static void NewInstanceHandler(object sender, StartupNextInstanceEventArgs e)
        {
            string imageLocation = e.CommandLine[1];
            MessageBox.Show(imageLocation);
            e.BringToForeground = false;
            ControlPanel.uploadImage(imageLocation);
        }
        public class SingleInstanceApplication : WindowsFormsApplicationBase
        {
            private SingleInstanceApplication()
            {
                base.IsSingleInstance = true;
            }
            public static void Run(Form f, StartupNextInstanceEventHandler startupHandler)
            {
                SingleInstanceApplication app = new SingleInstanceApplication();
                app.MainForm = f;
                app.StartupNextInstance += startupHandler;
                app.Run(Environment.GetCommandLineArgs());
            }
        }  
    }

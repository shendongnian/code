    static class Program
    {
        [STAThread]
       static void Main(params string[] Arguments)
       {
            Form1 MainForm;
            bool bInstanceFlag;
            Mutex MyApplicationMutex = new Mutex(true, "MyApp_Mutex", out bInstanceFlag);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        
            if (!bInstanceFlag)
            {
               MainForm = new Form1();
            SingleInstanceApplication.Run(MainForm, NewInstanceHandler);
        }
        else
        {
            MainForm = new Form1();
            SingleInstanceApplication.Run(MainForm, NewInstanceHandler);
            MainForm.Close();
        }
    }
    public static void NewInstanceHandler(object sender, StartupNextInstanceEventArgs e)
    {
        MainForm.AddItem = e.CommandLine[1];
        e.BringToForeground = false;
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

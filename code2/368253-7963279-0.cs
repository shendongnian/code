    using Microsoft.VisualBasic.ApplicationServices;
    public class Startup : WindowsFormsApplicationBase
    {
        protected override void OnCreateSplashScreen()
        {
            SplashScreen = new SplashForm();
        }
        protected override void OnCreateMainForm()
        {
            MainForm = new MyMainForm();
        }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Startup().Run(args);
        }
    }

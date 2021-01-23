    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainWindow = new frmMain();
            splashScreen.DisplaySplashScreen(mainWindow, 10000);
            ***mainWindow.TopMost = true;***
            Application.Run(mainWindow);
        }
    }

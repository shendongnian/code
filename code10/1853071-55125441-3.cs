    [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ValidatingSplash Splash = new ValidatingSplash();
            Splash.ShowDialog();
        }

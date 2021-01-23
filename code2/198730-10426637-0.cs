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
            var mainForm = new MainForm();
            
            // Add these lines:
            // ----------------------------------------------
            string[] args = Environment.GetCommandLineArgs();
            if (args.Count() >= 2)
                mainForm.LoadFile(args[1]);
            // ----------------------------------------------
            Application.Run(mainForm);
        }
    }

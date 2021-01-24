    static class Program
    {
        //  for external access to Form1 methods
        public static Form1 MainForm;
    
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new Form1(args);
            Application.Run(MainForm);
        }
    }

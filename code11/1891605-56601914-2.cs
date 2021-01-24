        static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (ValidUser() != true)
            {
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        private static bool ValidUser()
        {
            if (System.Environment.UserName == "Your_Username_Here")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

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
            using (LoginForm loginForm = new LoginForm){
               // show as dialog, grab the properties you want here
            }
            //then run the application
            Application.Run(new Form1());
        }
    }
    }

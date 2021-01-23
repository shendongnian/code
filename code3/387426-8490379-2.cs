    static class Program
    {
        private static bool canLogin;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (LoginForm loginForm = new LoginForm()){
               // show as dialog
               // perform logic to check if successful
               canLogin = SomeStaticClass.VerifyCredentials(loginForm.Credentials);
               // grab any properties you may want here
            }
            //then run the application
            if(canLogin){
               Application.Run(new Form1());
            }
        }
    }
    }

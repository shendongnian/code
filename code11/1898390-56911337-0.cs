    namespace Calculator_project
    {
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
                //Here Entry point run landing form of your application
                Application.Run(new Calculator()); 
            }
        }
    }

    static class Program
        {
    
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            private static void Main(string[] args)
            {
                //Start the webAPI
                WebApiProgram.StartMain();
    
                Thread.CurrentThread.CurrentCulture
                    = Thread.CurrentThread.CurrentUICulture
                        = CultureInfo.InvariantCulture;
    
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                var mainForm = new MainForm();
                Application.Run(mainForm);
            }
    
    
        }

        static void Main(string[] args) {
            AppDomain.CurrentDomain.UnhandledException += ReportAndRestart;
            // etc..
        }
        static void ReportAndRestart(object sender, UnhandledExceptionEventArgs e) {
            string info = e.ToString();
            // Log or display info 
            //...
            // Let the user know you're restarting
            //...
            System.Diagnostics.Process.Start(
                System.Reflection.Assembly.GetEntryAssembly().Location,
                string.Join(" ", Environment.GetCommandLineArgs()));
            Environment.Exit(1);
        }
    }

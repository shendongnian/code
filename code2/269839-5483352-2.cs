        [STAThread]
        static void Main() {
            // Test if any argument == "/batchmode" using upper or lowercase
            if (Environment.GetCommandLineArgs().Any(a => string.Equals(a, "/batchmode", StringComparison.InvariantCultureIgnoreCase)) {
                // Batch mode
            } else {
                // Interactive mode
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }

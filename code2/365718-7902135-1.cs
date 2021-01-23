    [STAThread]
    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            // Handle #2 here
        }
        else
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConfigurationActionManagerForm());
        }
    }

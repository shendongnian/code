    static void Main (string[] args)
    {
        var singleInstanceHandler = new SingleInstanceHandler(Application.ExecutablePath) { Timeout = 200 };
        singleInstanceHandler.Launching += (sender, e) =>
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(e.Args));
        };
        singleInstanceHandler.Connect(args);
    }

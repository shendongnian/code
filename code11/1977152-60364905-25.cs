    static void Main()
    {
    	Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);            
        PortableSettingsProvider.ApplyProvider(Properties.Settings.Default);
        Properties.Settings.Default.Reset();
        Application.Run(new MyTestApp());
    }

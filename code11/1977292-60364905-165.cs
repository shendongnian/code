    static void Main()
    {
    	Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        //PortableSettingsProvider.SettingsFileName = "settings.config";
        //PortableSettingsProvider.SettingsDirectory = "c:\\testconfig\\school";
        PortableSettingsProvider.ApplyProvider(Properties.Settings.Default);            
        Application.Run(new MyTestApp());
    }

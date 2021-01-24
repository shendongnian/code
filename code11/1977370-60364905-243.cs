    static void Main()
    {
    	Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);        
        //PortableSettingsProvider.SettingsFileName = "portable.config";
        //PortableSettingsProvider.SettingsDirectory = "c:\\testconfig\\school";
        //System.IO.Directory.CreateDirectory(PortableSettingsProvider.SettingsDirectory);
        PortableSettingsProvider.ApplyProvider(Properties.Settings.Default);            
        Application.Run(new MyTestApp());
    }

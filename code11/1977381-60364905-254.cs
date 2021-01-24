    static void Main()
    {
        Application.EnableVisualStyles();        
        PortableSettingsProvider.SettingsFileName = "settings.config";
        var strSettingsDirectory = Directory.GetCurrentDirectory() + "\\Settings";
        System.IO.Directory.CreateDirectory(strSettingsDirectory);
        PortableSettingsProvider.SettingsDirectory = strSettingsDirectory;
        PortableSettingsProvider.ApplyProvider(Properties.Settings.Default);
        Application.Run(new MyTestApp());
    }

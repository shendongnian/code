    static void Main()
    {
    	Application.EnableVisualStyles();
    	Application.SetCompatibleTextRenderingDefault(false);           
    	PortableSettingsProvider.ApplyProvider(Properties.Settings.Default);
    	Application.Run(new Form1());	
    }

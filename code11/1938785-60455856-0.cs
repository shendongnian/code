    static class Program
    {
    	static void Main()
    	{
    		DeviceServiceHostFactory deviceService = new DeviceServiceHostFactory();
    		deviceService.Start();
    		
    		Application.EnableVisualStyles();
    		Application.SetCompatibleTextRenderingDefault(false);
    		Application.Run(new MainWindow);
    	}
    }

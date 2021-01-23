    static void Main( string[] args )
    {
    	if( !Environment.UserInteractive )
    	{
    		var servicesToRun = new ServiceBase[] {new Service1Component()};
    		ServiceBase.Run( servicesToRun );
    	}
    	else
    	{
    		var services = new Service1Component();
    		services.Start()
    		Console.WriteLine( "Press return to exit" );
    		Console.ReadLine();
    		services.Stop();
    	}
    }

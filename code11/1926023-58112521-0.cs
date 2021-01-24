    public static void Main(string[] args)
    		{
    			try
    			{
    				var host = BuildWebHost(args);
    				using (var scope = host.Services.CreateScope())
    				{
    					var services = scope.ServiceProvider;
    					SeedData.Initialize(services).Wait();
    				}
    
    				host.Run();
    			}
    }

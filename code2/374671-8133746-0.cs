    static void Main(string[] args)
    {
    	LoggingManager.ConfigureAtStartup();
    
    	ErrorLogger.LogInformation("STARTED");
    
    	try
    	{
    		if (args.Length < 1)
    		{
    			ErrorLogger.LogInformation("No parameters provided...");
    			return;
    		}
    
    		int pingTimeoutMilliseconds = Convert.ToInt32(ConfigurationManager.AppSettings["pingTimeoutMilliseconds"]);
    
    		var urls = args[0].Split(';');
    
    		foreach (string url in urls)
    		{
    			if (string.IsNullOrWhiteSpace(url))
    			{
    				continue;
    			}
    
    			ErrorLogger.LogInformation(String.Format("Pinging url: {0}", url));
    
    			using (var client = new WebClient())
    			{
    				client.Credentials = CredentialCache.DefaultCredentials;
    
    				var stopW = new Stopwatch();
    
    				stopW.Start();
    
    				string result = client.DownloadString(url);
    
    				var elapsed = stopW.ElapsedMilliseconds;
    				stopW.Stop();
    
    				if (elapsed > pingTimeoutMilliseconds)
    				{
    					ErrorLogger.LogWarning(String.Format("{0} - took: {1} milliseconds to answer!", url, elapsed.ToString("N0")));
    
    					ErrorLogger.LogInformation(String.Format("Response was: {0} chars long", result.Length.ToString("n0")));
    				}                        
    			}
    		}
    	}
    	catch(Exception exc)
    	{
    		ErrorLogger.LogError(exc);
    	}
    	finally
    	{
    		ErrorLogger.LogInformation("COMPLETED");
    
    		LoggingManager.ShutdownOnExit();
    	}
    }

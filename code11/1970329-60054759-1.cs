    var serviceProvider = CreateServices(connectionString, commandLineArguments);
    
    // Put the database update into a scope to ensure
    // that all resources will be disposed.
    using (var scope = serviceProvider.CreateScope())
    {
    	try
    	{
    		UpdateDatabase(scope.ServiceProvider, commandLineArguments);
    	}
    	catch (Exception e)
    	{
    		Console.WriteLine("There was a problem with the migration: " + e.Message + "\n" +
    						  e.StackTrace);
    	}
    	migrationRun = true;
    }

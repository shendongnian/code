    private static void UpdateDatabase(IServiceProvider serviceProvider, CommandLineArguments commandLineArguments)
    {
    	// Instantiate the runner
    	var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
    
    	if (commandLineArguments.Downgrade)
    	{
    		runner.MigrateDown(commandLineArguments.Version != -1 ? commandLineArguments.Version : 0);
    	}
    	else
    	{
    		if (commandLineArguments.Version != -1)
    		{
    			runner.MigrateUp(commandLineArguments.Version);
    		}
    		else
    		{
    			runner.MigrateUp();
    		}
    
    	}
    }

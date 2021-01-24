    private static IServiceProvider CreateServices(string connectionString,
    	CommandLineArguments commandLineArguments)
    {
    	return new ServiceCollection()
    		// Add common FluentMigrator services
    		.AddFluentMigratorCore()
    		.ConfigureRunner(rb => rb
    			// Add SQL Server support to FluentMigrator
    			.AddSqlServer()
    			// Set the connection string
    			.WithGlobalConnectionString(connectionString)
    			
    			// Define the assembly containing the migrations
    			.ScanIn(typeof(Program).Assembly).For.Migrations().For.EmbeddedResources())
    		// Enable logging to console in the FluentMigrator way
    		.AddLogging(lb => lb.AddFluentMigratorConsole())
    		.Configure<RunnerOptions>(opt => { 
    			opt.Tags = commandLineArguments.Tags.ToArray();
    			opt.TransactionPerSession = true; })
    		// Build the service provider
    		.BuildServiceProvider(false);
    }

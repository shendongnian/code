    SqlDependencyEx sqlDependency;
    public SignalServer(TestController testController, IConfiguration configuration)
	{
		Configuration = configuration;
		_testController = testController;
		connectionString = Configuration.GetConnectionString("DefaultConnection");
        //Put it here
        sqlDependency = new SqlDependencyEx(connectionString);
	}

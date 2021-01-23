        //In Global.asax.cs 
        	protected void Application_Start()
        	{
		
		        ProfiledDbProviderFactoryForEntLib profiledProfiledDbProviderFactoryFor = ((ProfiledDbProviderFactoryForEntLib)DbProviderFactories.GetFactory("ProfiledDbProviderFactoryForEntLib"));
		        DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient"); //or whatever predefined factory you want to profile
		        profiledProfiledDbProviderFactoryFor.InitProfiledDbProviderFactory(MiniProfiler.Current, factory); 
		    ...
			
			

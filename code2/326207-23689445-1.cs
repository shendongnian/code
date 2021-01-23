    class AppDomainResolver
    {
    	string _sourceExeLocation;
    
    	public AppDomainResolver(string sourceExeLocation)
    	{
    		_sourceExeLocation = sourceExeLocation;
    		AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
    	}
    
    	Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    	{
    		if (args.Name.Contains("exporterLauncher")) // why does it not already know it has this assembly loaded? the seems to be required
    			return typeof(AppDomainResolver).Assembly;
    		else
    			return null;
    	}
    }

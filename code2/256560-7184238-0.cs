    Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
    	if (args.Name == "System.Data.SQLite")
    		return typeof (CollationSequence).Assembly;
    	else
    		return null;
    }

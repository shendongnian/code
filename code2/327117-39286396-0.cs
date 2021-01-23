    AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
    {
    	string resourceName = new AssemblyName(args.Name).Name + ".dll";
        string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));
        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
        {
		    Byte[] assemblyData = new Byte[stream.Length];
            stream.Read(assemblyData, 0, assemblyData.Length);
            return Assembly.Load(assemblyData);
	    }
    };

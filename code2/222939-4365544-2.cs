	foreach(Type oType in oAssemblies[assemblyCount].GetTypes())
	{
		if(typeof(IMFDBAnalyserPlugin).IsAssignableFrom(oType)) {
			assemblyNames.Add(args[assemblyCount].Substring(args[assemblyCount].LastIndexOf("\\") + 1));
		}
	}

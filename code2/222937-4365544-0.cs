	foreach(Type oType in oAssemblies[assemblyCount].GetTypes())
	{
		if(oType.IsSubclassOf(IMFDBAnalyserPlugin)) {
			assemblyNames.Add(args[assemblyCount].Substring(args[assemblyCount].LastIndexOf("\\") + 1));
		}
	}

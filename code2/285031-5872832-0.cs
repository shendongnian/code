    public static string[] GetResourcesUnder(string strFolder)
    {
    	strFolder = strFolder.ToLower() + "/";
    
    	var oAssembly = Assembly.GetCallingAssembly();
    	string strResources = oAssembly.GetName().Name + ".g.resources";
    	var oStream = oAssembly.GetManifestResourceStream(strResources);
    	var oResourceReader = new ResourceReader(oStream);
    
    	var vResources =
    		from p in oResourceReader.OfType<DictionaryEntry>()
    		let strTheme = (string)p.Key
    		where strTheme.StartsWith(strFolder)
    		select strTheme.Substring(strFolder.Length);
    
    	return vResources.ToArray();
    }

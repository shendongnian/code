    string[] GetRecentPlaces()
    {
    	var places = new List<string>();
    	foreach (var lnk in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Recent), "*.lnk"))
    	{
    		var path = LinkHelper.ResolveShortcut(lnk);
    		if ((new FileInfo(path).Attributes & FileAttributes.Directory) == FileAttributes.Directory)
    		{
    			places.Add(path);
    		}
    	}
    	return places.ToArray();
    }

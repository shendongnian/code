    IEnumerable<string> GetSubdirectories(string root)
    {
    	string[] subdirectories = Directory.GetDirectories(root);
    	foreach (var subdirectory in subdirectories)
    	{
    		yield return subdirectory;
    		foreach (var nestedDirectory in GetSubdirectories(subdirectory))
    		{
    			yield return nestedDirectory;
    		}
    	}
    }

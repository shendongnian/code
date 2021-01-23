    List<string> GetFilesAndFolders(string root, int depth)
    {
    	var list = new List<string>();
        foreach(var directory in Directory.EnumerateDirectories(root))
        {
	        list.Add(directory);
	        if (depth > 0)
	        {
		        list.AddRange(GetFilesAndFolders(directory, depth-1));
	        }
        }
	
        list.AddRange(Directory.EnumerateFiles(root));
	
        return list;
    }

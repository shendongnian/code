    Tuple<List<string>,List<string>> GetFilesAndFolders(string root, int depth)
    {
    	var folders = new List<string>();
        var files = new List<string>();
        foreach(var directory in Directory.EnumerateDirectories(root))
        {
	        folders.Add(directory);
	        if (depth > 0)
	        {
                    var result = GetFilesAndFolders(directory, depth-1);
                    folders.AddRange(result.Item1);
                    files.AddRange(result.Item2);
	        }
        }
	
        files.AddRange(Directory.EnumerateFiles(root));
	
        return new Tuple<List<string>,List<string>>(folders, files);
    }

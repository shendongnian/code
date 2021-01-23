    void MoveContentsOfDirectory(string source, string target)
    {
    	foreach (var file in Directory.EnumerateFiles(source))
    	{
    		var dest = Path.Combine(target, Path.GetFileName(file));
    		File.Move(file, dest);
    	}
    	
    	foreach (var dir in Directory.EnumerateDirectories(source))
    	{
    		var dest = Path.Combine(target, Path.GetFileName(dir));
    		Directory.Move(dir, dest);
    	}
    	
    	// optional
    	Directory.Delete(source);
    }

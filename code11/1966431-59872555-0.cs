    public static bool ComparePath(string path1,string path2)
    {	
    	return NormalizePath(path2).Contains(NormalizePath(path1));
    }
    
    public static string NormalizePath(string path)
    {
    	if(path.Trim().Last().Equals(Path.DirectorySeparatorChar))
    		return path.Trim().ToLower();
    	
    	
    	return $"{path.Trim()}{Path.DirectorySeparatorChar}";
    }

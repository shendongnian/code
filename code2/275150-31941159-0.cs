    public static class StringPathExtensions 
    {
    	public static bool IsSubPathOf(this string path, DirectoryInfo dir)
    	{
    		return path
    			.Replace('/', '\\')
    			.TrimEnd('\\')
    			.StartsWith(dir.FullName
    				.Replace('/', '\\')
    				.TrimEnd('\\', '/')
    		    , StringComparison.OrdinalIgnoreCase);
    	}
    }
    void Main()
    {
    	var paths = new[] { 
    		@"c:\foo\bar\baz",		// 2 subfolder levels
    		@"c:\foo\bar\",			// subfolder, end with \
    		@"c:\foo\bar/",			// subfolder, end with /
    		@"c:/foo/bar/",			// subfolder, / delimiters
    		@"c:\foo\bar",			// subfolder, no delimiter
    		@"c:\FOO\BAR",			// subfolder, different case
    		@"c:\foo\bar\file.txt"	// file in subfolder
    	};
    	
    	var dirs = new[]{ @"c:\foo\", @"c:\foo", @"c:\FOO", @"c:\", "c:" };
    	
    	foreach (var dirPath in dirs)
    	foreach (var path in paths)
    	{
    		var dir = new DirectoryInfo(dirPath);
    		Console.WriteLine(dir.ToString().PadRight(8)+" vs "+path.PadRight(21)+": "+path.IsSubPathOf(dir));
    	}	
    }
    

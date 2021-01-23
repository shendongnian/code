    static string path = @"C:\Work\Build";
		
    public static void Main(string[] args)
    {
        var files = Directory.GetFiles(path, "SASE Lab Tools.*");
        // Remove after testing
        foreach(var file in files)
            Console.WriteLine(file);
		
        Console.WriteLine("");
		
        foreach(var file in files.OrderByDescending(x=>x).Skip(7))
            Console.WriteLine(file);
        // END Remove after testing
		
        foreach(var file in files.OrderByDescending(x=>x).Skip(7))
    	    File.Delete(file);
    }

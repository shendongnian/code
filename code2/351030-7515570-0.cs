    public static void GenerateList(String dirPath, String fileName) {
    	var dir1 = new DirectoryInfo(dirPath);
    
    	try {
    		var lines = from f in dir1.EnumerateFileSystemInfos("*", SearchOption.AllDirectories)
    					select f.FullName + "::" + f.CreationTime.ToShortDateString();
    
    		File.WriteAllLines(fileName, lines);
    	}
    	catch (Exception ex) {
    		Console.WriteLine(ex);
    	}
    }

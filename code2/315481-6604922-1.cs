	public static void Main()
	{
		TreeScan(@"C:\someFolder");
	}
	
	private static void TreeScan(string sDir)
    {
		foreach (string f in Directory.GetFiles(sDir))
			Console.WriteLine("File: " + f); // or some other file processing
	
        foreach (string d in Directory.GetDirectories(sDir))
            TreeScan(d); // recursive call to get files of directory
    }

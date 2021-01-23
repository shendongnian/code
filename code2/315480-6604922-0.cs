	public static void Main()
	{
		TreeScan(@"C:\someFolder");
	}
	
	private static void TreeScan(string sDir)
    {
		foreach (string f in Directory.GetFiles(sDir))
        {
			Console.WriteLine("File: " + f);
		}
		
        foreach (string d in Directory.GetDirectories(sDir))
        {
        	Console.WriteLine("Folder: " + d);
            TreeScan(d);
        }
    }

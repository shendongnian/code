	public static bool IsZipValid(string basePath, string fileNameWithWildcard)
	{
	    try
		{
			List<string> files = System.IO.Directory.EnumerateFiles(
						basePath, fileNameWithWildcard, 
						SearchOption.TopDirectoryOnly).OrderBy(x => x).ToList();
	
			using (var zipFile = // ... rest is as Manoj wrote

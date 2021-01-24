	public static bool IsZipValid(string basePath, string fileNameWithWildcard)
	{
	    try
		{
			List<string> files = System.IO.Directory.EnumerateFiles(
						basePath, fileNameWithWildcard, 
						SearchOption.TopDirectoryOnly).OrderBy(x => x).ToList();
	
			using (var zipFile = new ZipArchive(new CombinationStream(
			              files.Select(x => new FileStream(x, FileMode.Open)))))
			{
				// ...
			}
	
		}
		catch (InvalidDataException ex)
		{
			return false;
		}
	
		return true;
	}

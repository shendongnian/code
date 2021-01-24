	List<string> getZipFormat(string path)
	{
		bool filesFound(string basePath, string pattern) => System.IO.Directory.EnumerateFiles(
				basePath, pattern, SearchOption.TopDirectoryOnly).Any();
	
		var isTar = filesFound(path, "*.tar");
		var isZip = filesFound(path, "*.zip") || filesFound(path, "*.z??");
		var is7Zip = filesFound(path, "*.7z");
	
		var result = new List<string>();
		if (isTar) result.Add("TAR");
		if (isZip) result.Add("ZIP");
		if (is7Zip) result.Add("7ZIP");
		return result;
	}

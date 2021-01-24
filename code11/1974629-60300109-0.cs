	public async Task ProcessFile(IFormFile file)
	{
		if (!Path.GetExtension(file.FileName).Equals(".zip"))
			throw new System.Exception("File should be compressed in '.zip' format");
		var filePaths = new List<string>();
		using (var stream = new MemoryStream())
		{
			await file.CopyToAsync(stream);
			using (var archive = new ZipArchive(stream, ZipArchiveMode.Read, false))
			{
				var replaceList = new Dictionary<string, string>();
				foreach (ZipArchiveEntry entry in archive.Entries)
				{
					var tempPath = Path.GetTempFileName();
					string key = Path.GetFileNameWithoutExtension(entry.FullName);
					string value = Path.GetFileNameWithoutExtension(tempPath);
					if (replaceList.ContainsKey(key))
					{
						value = replaceList[key];
					}
					else
					{
						replaceList.Add(key, value);
					}
					string unzippedPath = Path.Combine(Path.GetDirectoryName(tempPath), value + Path.GetExtension(entry.FullName));
					entry.ExtractToFile(unzippedPath, true);
					filePaths.Add(unzippedPath);
				}
				foreach (var unzippedPath in filePaths)
				{
					if (Path.GetExtension(unzippedPath).Equals(".shp"))
					{
						// Successfully doing third-party library stuff
					}
				}
				foreach (var unzippedPath in filePaths)
				{
					if (File.Exists(unzippedPath))
					{
						File.Delete(unzippedPath);
					}
				}
			}
		}
	}

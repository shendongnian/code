	var zipFiles = _directory.ListFilesAndDirectories()
		.OfType<CloudFile>()
		.Where(x => x.Name.ToLower().Contains(".zip"))
		.ToList();
	foreach (var zipFile in zipFiles)
	{
		using (var zipArchive = new ZipArchive(zipFile.OpenRead()))
		{
			foreach (var entry in zipArchive.Entries)
			{
				if (entry.Length > 0)
				{
					CloudFile extractedFile = _directory.GetFileReference(entry.Name);
					using (var entryStream = entry.Open())
					{
						byte[] buffer = new byte[16 * 1024];
						using (var ms = extractedFile.OpenWrite(entry.Length))
						{
							int read;
							while ((read = entryStream.Read(buffer, 0, buffer.Length)) > 0)
							{
								ms.Write(buffer, 0, read);
							}
						}
					}
				}
			}
		}				
	}

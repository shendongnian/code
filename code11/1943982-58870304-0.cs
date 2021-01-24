	// Usings:
	//  SharpCompress.Archives;
	//  SharpCompress.Common;
	//  System.Linq;
	private static bool ExtractFile(string archivePath, string destPath, string fileSubstring)
	{
		using (var archive = ArchiveFactory.Open(archivePath))
		{
			var entry = archive.Entries.FirstOrDefault(e => e.Key.Contains(fileSubstring));
			if (entry != null)
			{
				var opt = new ExtractionOptions
				{
					ExtractFullPath = false,
					Overwrite = true
				};
				try
				{
					entry.WriteToDirectory(destPath, opt);
					return true;
				}
				catch { }
			}
		}
		return false;
	}

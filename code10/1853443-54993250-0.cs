	private IEnumerable<(string Path, byte[] Content)> ExtractZipFile(byte[] messagePart)
	{
		using (var data = new MemoryStream(messagePart))
		{
			using (var zipFile = ZipFile.Read(data))
			{
				foreach (var zipEntry in zipFile)
				{
					using (var memoryStream = new MemoryStream())
					{
						zipEntry.Extract(memoryStream);
						yield return (Path: zipEntry.FileName, Content: memoryStream.ToArray());
					}
				}
			}
		}
	}

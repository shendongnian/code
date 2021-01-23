	public static byte[] Compress(byte[] fi)
	{
		using (MemoryStream outFile = new MemoryStream())
		{
			using (MemoryStream inFile = new MemoryStream(fi))
			using (GZipStream Compress = new GZipStream(outFile, CompressionMode.Compress))
			{
				inFile.CopyTo(Compress);
			}
			return outFile.ToArray();
		}
	}

	public static byte[] ReadAllBytes(this BinaryReader reader)
	{
		const int bufferSize = 4096;
		using (var ms = new MemoryStream())
		{
			byte[] buffer = new byte[bufferSize];
			int count;
			while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
				destination.Write(buffer, 0, count);
			return ms.ToArray();
		}
		
	}

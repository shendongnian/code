	public static string DecodeGzip(string str)
	{
		byte[] gzBuffer = Convert.FromBase64String(str);
	
		using (MemoryStream ms = new MemoryStream())
		{
			int msgLength = BitConverter.ToInt32(gzBuffer, 0);
			ms.Write(gzBuffer, 0, gzBuffer.Length);
	
			byte[] buffer = new byte[msgLength];
	
			ms.Position = 0;
			int length;
			using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress))
			{
				length = zip.Read(buffer, 0, buffer.Length);
			}
			
			var data = new byte[length];
			Array.Copy(buffer, data, length);
			return Encoding.UTF8.GetString(data);
	
		}
	}

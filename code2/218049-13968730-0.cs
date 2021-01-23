	FileInfo file = new FileInfo("input.ext");
	using(var sw = new FileStream("output.zip", FileMode.OpenOrCreate, FileAccess.ReadWrite))
	{
		using(var zipStream = new ZipOutputStream(sw))
		{
		    var entry = new ZipEntry(file.Name);
		    entry.IsUnicodeText = true;
		    zipStream.PutNextEntry(entry);
		
		    using (var reader = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
		    {
		        byte[] buffer = new byte[4096];
		        int bytesRead;
		        while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
		        {
		            byte[] actual = new byte[bytesRead];
		            Buffer.BlockCopy(buffer, 0, actual, 0, bytesRead);
		            zipStream.Write(actual, 0, actual.Length);
		        }
		    }
		}
	}

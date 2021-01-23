    using (var fs = File.OpenRead(filePath))
    {
    	fs.Seek(0, SeekOrigin.End);
    	
    	int newLines = 0;
    	while (newLines < 3)
    	{
    		fs.Seek(-1, SeekOrigin.Current);
    		newLines += fs.ReadByte() == 13 ? 1 : 0; // look for \r
    		fs.Seek(-1, SeekOrigin.Current);
    	}
    
    	byte[] data = new byte[fs.Length - fs.Position];
    	fs.Read(data, 0, data.Length);
    }

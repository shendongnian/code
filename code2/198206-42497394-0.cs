    public static void MonitorTailOfFile(string filePath)
    {
    	var initialFileSize = new FileInfo(filePath).Length;
    	var lastReadLength = initialFileSize - 1024;
    	if (lastReadLength < 0) lastReadLength = 0;
    
    	while (true)
    	{
    		try
    		{
    			var fileSize = new FileInfo(filePath).Length;
    			if (fileSize > lastReadLength)
    			{
    				using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    				{
    					fs.Seek(lastReadLength, SeekOrigin.Begin);
    					var buffer = new byte[1024];
    
    					while (true)
    					{
    						var bytesRead = fs.Read(buffer, 0, buffer.Length);
    						lastReadLength += bytesRead;
    
    						if (bytesRead == 0)
    							break;
    
    						var text = ASCIIEncoding.ASCII.GetString(buffer, 0, bytesRead);
    
    						Console.Write(text);
    					}
    				}
    			}
    		}
    		catch { }
    
    		Thread.Sleep(1000);
    	}
    }

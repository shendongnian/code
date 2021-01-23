    public string Compress(FileInfo fi)
    {
    	string outPath;
    
    	using (FileStream inFile = fi.OpenRead())
    	{
    		outPath = fi.FullName + ".gz";
    		using (FileStream outFile = File.Create(outPath))
    		{
    			using (var compress = new GZipStream(outFile, 
                                                     CompressionMode.Compress))
    			{
    				inFile.CopyTo(compress);
    			}
    		}
    	}
    
    	return outPath;
    }
    
    public void Decompress(FileInfo fi)
    {
    	using (FileStream inFile = fi.OpenRead())
    	{
    		string curFile = fi.FullName;
    		string origName = curFile.Remove(curFile.Length - fi.Extension.Length);
    
    		using (FileStream outFile = File.Create(origName))
    		{
    			using (var decompress = new GZipStream(inFile, 
                                                       CompressionMode.Decompress))
    			{
    				decompress.CopyTo(outFile);
    			}
    		}
    	}
    }

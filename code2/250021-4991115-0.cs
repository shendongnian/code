    int fileSize = 719585280;
    var bufLength = 4096;
    byte[] random = new byte[bufLength];
    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
    
    var bytesRemaining = fileSize;
    
    using(var fs=File.Create("c:\crypto.bin"))
    {
    	while(bytesRemaining > 0)
    	{
    		rng.GetBytes(random);
    		var bytesToWrite = Math.Min(bufLength, bytesRemaining);
    		fs.Write(random, 0, bytesToWrite);
    		bytesRemaining -= bytesToWrite;
    	}
    }

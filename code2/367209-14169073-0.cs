    void Main()
    {
    	 var mp3Path = @"C:\Users\Ronnie\Desktop\podcasts\hanselminutes_0350.mp3";	
    	 var outputPath = Path.ChangeExtension(mp3Path,".trimmed.mp3");
    	 
    	 TrimMp3(mp3Path, outputPath, TimeSpan.FromMinutes(2), TimeSpan.FromMinutes(2.5));
    }
    
    void TrimMp3(string inputPath, string outputPath, TimeSpan? begin, TimeSpan? end)
    {
    	if (begin.HasValue && end.HasValue && begin > end)
    		throw new ArgumentOutOfRangeException("end", "end should be greater than begin");
    
    	using (var reader = new Mp3FileReader(inputPath))
    	using(var writer = File.Create(outputPath))
    	{			
    		Mp3Frame frame;
    		while ((frame = reader.ReadNextFrame()) != null)
    		if (reader.CurrentTime >= begin || !begin.HasValue)
    		{
    			if (reader.CurrentTime <= end || !end.HasValue)
    				writer.Write(frame.RawData,0,frame.RawData.Length);			
    			else break;
    		}
    	}
    }

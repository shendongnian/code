    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
    GC.WaitForPendingFinalizers();
    var sbJsv = new StringBuilder();
    using (var sw = new StringWriter(sbJsv))
    {
    	Console.WriteLine();
    	Console.WriteLine(typeof(TypeSerializer).Name);
    	TypeSerializer.SerializeToWriter(orig, sw);
    	var jsv = sbJsv.ToString();
    	Console.WriteLine("Length: " + sbJsv.Length);
    	TypeSerializer.DeserializeFromString<Game>(jsv);
    
    	var watch = Stopwatch.StartNew();
    	for (int i = 0; i < LOOP; i++)
    	{
    		TypeSerializer.SerializeToWriter(orig, sw);
    	}
    	watch.Stop();
    	Console.WriteLine("Serialize: " + watch.ElapsedMilliseconds);
    
    	watch = Stopwatch.StartNew();
    	for (int i = 0; i < LOOP; i++)
    	{
    		TypeSerializer.DeserializeFromString<Game>(jsv);
    	}
    	watch.Stop();
    	Console.WriteLine("Deserialize: " + watch.ElapsedMilliseconds);
    }
    
    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
    GC.WaitForPendingFinalizers();
    var sbJson = new StringBuilder();
    using (var sw = new StringWriter(sbJson))
    {
    	Console.WriteLine();
    	Console.WriteLine(typeof(JsonSerializer).Name);
    	JsonSerializer.SerializeToWriter(orig, sw);
    	var json = sbJson.ToString();
    	Console.WriteLine("Length: " + sbJson.Length);
    	JsonSerializer.DeserializeFromString<Game>(json);
    
    	var watch = Stopwatch.StartNew();
    	for (int i = 0; i < LOOP; i++)
    	{
    		JsonSerializer.SerializeToWriter(orig, sw);
    	}
    	watch.Stop();
    	Console.WriteLine("Serialize: " + watch.ElapsedMilliseconds);
    
    	watch = Stopwatch.StartNew();
    	for (int i = 0; i < LOOP; i++)
    	{
    		JsonSerializer.DeserializeFromString<Game>(json);
    	}
    	watch.Stop();
    	Console.WriteLine("Deserialize: " + watch.ElapsedMilliseconds);
    }
 

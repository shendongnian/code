    var json = "{  \r\n \"name[0]\":\"cat\",\r\n \"map[0]\":\"catmap\",\r\n \"name[1]\":\"dog\",\r\n \"map[1]\":\"dogmap\",\r\n \"name[2]\":\"lion\",\r\n \"map[2]\":\"lionmap\",\r\n \"name[3]\":\"tiger\",\r\n \"map[3]\":\"tigermap\",\r\n \"name[4]\":\"snake\",\r\n \"map[4]\":\"snakemap\"\r\n}";
    
    var jObject = JObject.Parse(json);
    
    var list = new List<Animal>();
    
    for (int i = 0; i < jObject.Count / 2; i++)
    {
    	list.Add(new Animal
    	{
    		Name = jObject.GetValue($"name[{i}]").ToString(),
    		Map = jObject.GetValue($"map[{i}]").ToString()
    	});
    }

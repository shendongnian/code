    static JsonSerializerSettings withTypes= new JsonSerializerSettings
    {
      TypeNameHandling = TypeNameHandling.All
    };
	var serialized = JsonConvert.SerializeObject(myZoneArray, withTypes);
	Console.WriteLine(serialized);
	var result= JsonConvert.DeserializeObject<Zone[]>(serialized,withTypes);

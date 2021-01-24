	var settings = new JsonSerializerSettings
	{
		StringEscapeHandling = StringEscapeHandling.EscapeHtml,
	};
	var serialized = JsonConvert.SerializeObject(test, Formatting.None, settings);
	
	Console.WriteLine(serialized);
	// Outputs {"vehicleTrim":"designer\u0027s package"}
	
	Assert.IsTrue(!serialized.Contains('\'')); 
	// Succeeds

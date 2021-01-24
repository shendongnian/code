	var options = new JsonSerializerOptions
	{
		Converters = { new SingleOrArrayConverterFactory() },
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
	};
    var list = JsonSerializer.Deserialize<List<Item>>(json, options);

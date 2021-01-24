	var options = new JsonSerializerOptions
	{
		Converters = { new DictionaryConverterFactory() },
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
	};
	var json = JsonSerializer.Serialize(dictionary, options);
	var dictionary2 = JsonSerializer.Deserialize<TDictionary>(json, options);

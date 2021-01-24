	var stack = new Stack<int>(new [] { 1, 2, 3 });
	var options = new JsonSerializerOptions
	{
		Converters = { new StackConverterFactory() },
	};
	
	var json = JsonSerializer.Serialize(stack, options);
	
	var stack2 = JsonSerializer.Deserialize<Stack<int>>(json, options);
	
	var json2 = JsonSerializer.Serialize(stack2, options);
	Assert.IsTrue(stack.SequenceEqual(stack2)); // Passes
	Assert.IsTrue(json == json2);  // Passes

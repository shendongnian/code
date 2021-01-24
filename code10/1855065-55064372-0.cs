    string pattern = @"\.|\&|\@(?![^@]+$)|[^a-zA-Z@]";
    string input = "username@middle&something.else@company.com";
		
	string inputBeforeLastAt = input.Substring(0, input.LastIndexOf('@'));
	// input, pattern, replacement
	string result = Regex.Replace(inputBeforeLastAt, pattern, string.Empty) + input.Substring(input.LastIndexOf('@'));
	Console.WriteLine(result);

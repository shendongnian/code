	static bool IsValid(string input)
	{
		return !string.IsNullOrEmpty(input)
            && input.Length < 3 && !input.StartsWith("0") && input.All(char.IsDigit); 
	}

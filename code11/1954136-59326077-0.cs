	public static string Generate(int size, int? maxDigits = null, int? maxLowerCase = null, int? maxUpperCase= null)
	{
		if (maxDigits.HasValue && maxLowerCase.HasValue && maxUpperCase.HasValue && maxDigits + maxLowerCase + maxUpperCase< size)
		{
			throw new ArgumentOutOfRangeException($"Can't generate a string of length {size} with the given limits");
		}
		
		const string chars = "abcdefghijklmnopqrstuvwxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		
		var passwordBuilder = new StringBuilder();
		var random = new Random();
		
		int digitCount = 0, lowerCaseCount = 0, upperCaseCount = 0;
		
		while (passwordBuilder.Length < size)
		{
			var nextCharacter = chars[random.Next(chars.Length)];
			
			if (char.IsDigit(nextCharacter) && (!maxDigits.HasValue || digitCount < maxDigits))
			{
				passwordBuilder.Append(nextCharacter);
				digitCount++;
			}
			if (char.IsLower(nextCharacter) && (!maxLowerCase.HasValue || lowerCaseCount < maxLowerCase))
			{
				passwordBuilder.Append(nextCharacter);
				lowerCaseCount++;
			}
			if (char.IsUpper(nextCharacter) && (!maxUpperCase.HasValue || upperCaseCount < maxUpperCase))
			{
				passwordBuilder.Append(nextCharacter);
				upperCaseCount++;
			}
		}
		return passwordBuilder.ToString();
	}

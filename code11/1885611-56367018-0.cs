	public static void Main()
	{
		var wsChars = Enumerable.Range(0, ushort.MaxValue)
                                .Where(c => char.IsWhiteSpace(Convert.ToChar(c)))
                                .Select(c => Convert.ToChar(c)).ToArray();
		
		Console.WriteLine(wsChars.Length);
		
		var someText = "This_is_a\tstring with \nsome whitespace characters.";
		
		Console.WriteLine(someText.IndexOfAny(wsChars));
	}

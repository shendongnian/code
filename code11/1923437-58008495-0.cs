	public static void Main()
	{
		var source = @"filename_A_123_456789.xml";
		var slices =  Path.GetFileNameWithoutExtension(source).Split('_');
		var last = slices.Last();
		var isSpecific = last.Length == 6 && last.All(char.IsDigit);
		var result = string.Join("_", isSpecific ? slices.Take(slices.Length - 1) : slices) + Path.GetExtension(source);
		Console.WriteLine(result);
	}

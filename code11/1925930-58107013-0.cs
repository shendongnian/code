static void Main(string[] args)
{
	// Example dictionary from
	// from https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=netframework-4.8
	// Create a new dictionary of strings, with string keys.
	//
	Dictionary<string, string> openWith =
		new Dictionary<string, string>();
	// Add some elements to the dictionary. There are no 
	// duplicate keys, but some of the values are duplicates.
	openWith.Add("txt", "notepad.exe");
	openWith.Add("bmp", "paint.exe");
	openWith.Add("dib", "paint.exe");
	openWith.Add("rtf", "wordpad.exe");
	Print(openWith);
}
static void Print<T, U>(Dictionary<T, U> data)
{
	foreach (var o in data)
	{
		Console.WriteLine(o);
	}
}

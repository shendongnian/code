	public static void Main()
	{
        var myDictionary = new Dictionary<string, dynamic> {
            { "ID1", 12 },
            { "ID2", "Text2"},
            { "ID3", "Text3" }
        };	
		dynamic myObject = new DynamicDictionaryWrapper(myDictionary);
		
		Console.WriteLine(myObject.ID1);
		Console.WriteLine(myObject.ID2);
		Console.WriteLine(myObject.ID3);
	}

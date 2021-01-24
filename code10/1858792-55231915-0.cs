	public static void Main()
	{
		dynamic d = new ExpandoObject();
		
		d.Foo = "Hello";
		
		Console.WriteLine("Should have one  property:");
		foreach (var i in d )
		{
			Console.WriteLine("Name: {0} Type: {1} Value: {2}", i.Key, i.Value.GetType().Name, i.Value);
		}
		
		Console.WriteLine("\r\nShould have two properties:");
		
    	d.Bar = 123.45F;
		
		foreach (var i in d)
		{
			Console.WriteLine("Name: {0} Type: {1} Value: {2}", i.Key, i.Value.GetType().Name, i.Value);
		}
	}

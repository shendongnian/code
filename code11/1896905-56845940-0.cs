	public static void Main()
	{
		var tests = new string[]
		{
			 "I am OK",
             " I am OK ",
             "  I am OK",
             "I am OK  ",
             " I am  OK " 
		};
		foreach (var test in tests)
		{
			var hasDoubleSpace = (test.IndexOf("  ") != -1);
			Console.WriteLine("'{0}' {1} double spaces", test, hasDoubleSpace ? "has" : "does not have");
		}
	}

	{
		// Check the value to see what the range of the enumeration is
		var lastVal = Enum.GetValues(typeof(TestEnum)).Cast<TestEnum>().Last();
		long limit = (long)lastVal * 2;
		Console.WriteLine("Limit of flags for TestEnum is: " + limit);
		Func<long, bool> testLambda = x => x < limit;
		Console.WriteLine("Value of {0} within limit: {1}", 14, testLambda(14));
		Console.WriteLine("Value of {0} within limit: {1}", 16, testLambda(16));
		Console.WriteLine("Value of {0} within limit: {1}", 200, testLambda(200));
		Console.WriteLine("Value of {0} within limit: {1}", 0, testLambda(0));
		Console.WriteLine("Out of range looks like: " + (TestEnum)17);
		Console.WriteLine("In range looks like: " + (TestEnum)14);
	}

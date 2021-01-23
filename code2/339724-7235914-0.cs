		var numbers = new[]
		              	{
		              		"    _  _     _  _  _  _  _ ",
		              		"  | _| _||_||_ |_   ||_||_|",
		              		"  ||_  _|  | _||_|  ||_| _|"
		              	};
                // just in case length is off on one, don't want to crash
		var length = numbers.Min(line => line.Length);
		var results = new List<string>();
                // go by groups of three
		for (int i = 0; i < length; i += 3)
		{
			var builder = new StringBuilder();
			for (int j = 0; j < numbers.Length; j++)
			{
				builder.Append(numbers[j].Substring(i, 3));
			}
			results.Add(builder.ToString());
		}
                // print the results
		foreach (var digit in results)
		{
			Console.WriteLine(digit);
		}

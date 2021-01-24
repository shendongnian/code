		var input = Console.ReadLine();
		double parsedDouble;
		if (input.Contains(","))
		{
			input = input.ToString().Replace(",", ".");
		}
		if (!Double.TryParse(input, out parsedDouble))
		{
			Console.WriteLine("Error parsing input");
		}
		else
		{
			Console.WriteLine(parsedDouble);
		}
		Console.ReadLine();

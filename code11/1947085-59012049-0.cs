    double  a = 0.0, b = 0.0, c = 0.0;
	Console.WriteLine("please enter the values of: a b c");
	string input = Console.ReadLine();
	string[] inputParts = input.Split(' ');
	if (inputParts.Length > 0 && inputParts[0] != null) 
	{
		Double.TryParse(inputParts[0], out a);
	}
	if (inputParts.Length > 1 && inputParts[1] != null) 
	{
		Double.TryParse(inputParts[1], out b);
	}
	if (inputParts.Length > 2 && inputParts[2] != null) 
	{
		Double.TryParse(inputParts[2], out c);
	}
	Console.WriteLine($"a: {a.ToString()}");
	Console.WriteLine($"b: {b.ToString()}");
	Console.WriteLine($"c: {c.ToString()}");

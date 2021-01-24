	if (ulong.TryParse(Console.ReadLine(), out ulong parsedValue))
	{
		Console.WriteLine($"You entered {parsedValue}.");
	}
	else
	{
		Console.WriteLine("Please enter a valid value.");
	}

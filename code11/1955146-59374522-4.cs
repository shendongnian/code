	int i = 5, input = 0;
	while (i > 0)
	{
		input *= 10;
		input += i--;
	}
	while (input > 10)
	{
		Console.WriteLine(input);
		input /= 10;
	}
	while (input > 0)
	{
		Console.WriteLine(input--);
	}

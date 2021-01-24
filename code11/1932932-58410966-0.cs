	int a, b;
	a = int.Parse(Console.ReadLine());
	var result = new List<int>();
	for (b = 1; b <= a; b++)
	{
		if (a % b == 0)
		{
			result.Add(b);
		}
	}
    Console.Write(string.Join(" and ", result));

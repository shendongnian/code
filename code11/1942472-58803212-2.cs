		int sum = 0;
		for (int i = 1; i < 9; i++)
		{
			int current = 0;
			for (int j = 1; j <= i; j += 2)
			{
				Console.Write(i);
                current = 10 * current + i;
			}
			Console.WriteLine();
			sum += current;
		}
		Console.WriteLine("Summary: " + sum);
	

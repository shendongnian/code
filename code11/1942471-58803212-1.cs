		int sum = 0;
		for (int i = 1; i < 9; i++)
		{
			string current = "";
			for (int j = 1; j <= i; j += 2)
			{
				Console.Write(i);
				current += i.ToString();
			}
			Console.WriteLine();
			sum += int.Parse(current);
		}
		Console.WriteLine("Summary: " + sum);
	

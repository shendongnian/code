		List<int[]> array1 = new List<int[]> { 
			new [] {10, 20, 10, 20 },
			new [] {3, 27, 5, 45 },
			new [] {17, 20, 20, 33 },
			new [] {21, 35, 15, 54 }
		};
		int input = 0;
		while(input < array1.Count)
		{
			Console.Write("Enter the number of the Row you would like to see the sum of: ");
			input = int.Parse(Console.ReadLine());
			if (input > array1.Count)
				Console.Write(-1);			
			else
			{
				int total = array1.ElementAt(input - 1).Sum(i => i);
				Console.WriteLine("The sum of Row {0} is {1} ", input, total);
			}
		}

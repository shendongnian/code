	public static IEnumerable<IEnumerable<int>> Combinations (int[,] array, int column)
	{
		if (column == array.GetLength(1)) 
		{
		   yield return Enumerable.Empty<int>();
		   yield break;
		};
		
		for(int j=0; j < array.GetLength(0); j++)
		{
			int v = array[j, column];
			var first = new List<int>{ v };
			foreach (var combination in Combinations(array, column+1))
			{
				yield return first.Concat(combination);
			}
		}
	}
	
	
	public static void Main()
	{
		int [,] a = new int [2,3] {
		   {1, 2, 3} ,
		   {2, 3, 4} ,
		};
		
		var result = Combinations(a, 0);
		foreach (var t in result)
		{
		   Console.WriteLine(string.Join(",", t));
		}
	}

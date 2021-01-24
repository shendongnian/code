	var source = new int[,]
	{
		{ 1, 2, 3 },
		{ 1, 2, 3 },
		{ 1, 2, 3 },
		{ 1, 2, 3 },
	};
	
	int[] third = Enumerable.Range(0, source.GetLength(0)).Select(x => source[x, 2]).ToArray();

	int[,] grid = new int[3, 5]
	{
		{ 0, 1, 0, 0, 0},
		{ 0, 1, 0, 1, 0},
		{ 0, 0, 0, 1, 6},
	};
	List<(int r, int c)> path = RecursiveCheck(grid, (r: 0, c: 0), 6);
	Console.WriteLine(path.Count);

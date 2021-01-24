	private List<(int r, int c)> RecursiveCheck(int[,] grid, List<(int r, int c)> path, int goal)
	{
		foreach (var neighbour in GetNeighbours(grid, path.Last()))
		{
			if (!path.Contains(neighbour))
			{
				var next = path.Concat(new[] { neighbour }).ToList();
				if (grid[neighbour.r, neighbour.c] == goal)
				{
					return next;
				}
				else if (grid[neighbour.r, neighbour.c] == 0)
				{
					return RecursiveCheck(grid, next, goal);
				}
			}
		}
		return new List<(int r, int c)>();
	}

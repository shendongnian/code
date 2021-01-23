	public static Rect[,] GetCellRects(this Grid grid) =>
                          GetCellRects(grid.RowDefinitions, grid.ColumnDefinitions);
	static Rect[,] GetCellRects(RowDefinitionCollection rows, ColumnDefinitionCollection cols)
	{
		int i = rows.Count, j = cols.Count;
		var a = new Rect[i, j];
		if (i > 0 && j > 0)
		{
			Double x;
			for (i = a.GetLength(0); --i >= 0;)
				for (x = rows[i].ActualHeight, j = a.GetLength(1); --j >= 0;)
					a[i, j].Height = x;
			for (j = a.GetLength(1); --j >= 0;)
				for (x = cols[j].ActualWidth, i = a.GetLength(0); --i >= 0;)
					a[i, j].Width = x;
			for (i = 0; i < a.GetLength(0); i++)
				for (j = 0; j < a.GetLength(1); j++)
				{
					if (j > 0)
						a[i, j].X = a[i, j - 1].Right;
					if (i > 0)
						a[i, j].Y = a[i - 1, j].Bottom;
				}
		}
		return a;
	}

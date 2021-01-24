    private static List<T[]> SplitArray<T>(T[,] sourceArray)
	{
		List<T[]> result = new List<T[]>();
		int rowCount = sourceArray.GetLength(0);
		for (int i = 0; i < rowCount; i++)
		{
			result.Add(GetRow(sourceArray, i));
		}
		return result;
	}
	
	private static T[] GetRow<T>(T[,] sourceArray, int rownumber)
	{
		int columnCount = sourceArray.GetLength(1);
		var row = new T[columnCount];
		for (int i = 0; i < columnCount; i++)
		{
			row[i] = sourceArray[rownumber, i];
		}
		return row;
	}

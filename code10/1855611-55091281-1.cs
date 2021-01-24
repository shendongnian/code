	void FallDown(ref int[,] numbers)
	{
		var rowCount = numbers.GetLength(0);
		for (var c = 0; c < numbers.GetLength(1); c++)
		{
			var colValues = new List<int>();
			for (var r = 0; r < rowCount; r++)
			{
				var colValue = numbers[r, c];
				if (colValue > 0)
				{
					colValues.Add(colValue); // collect only non-zero values
				}
			}
			if (colValues.Count < rowCount) // there were zeroes ...
			{
				do
				{
					colValues.Insert(0, 0); // fill it up with leading zeroes.
				} while (colValues.Count < rowCount);
				for (var r = 0; r < rowCount; r++) {
					numbers[r, c] = colValues[r]; // put numbers back into original array
				}
			}
		}
	}

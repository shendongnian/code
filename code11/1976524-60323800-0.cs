public static string[,] SkipBlankRows(this string[,] array2D)
{
	int columnCount = array2D.GetLength(1);
	var withoutEmptyLines = array2D
		.Cast<string>()  // Flatten the 2D array to an IEnumerable<string>
		.Select((str, idx) => new { str, idx }) // Select the string with its index
		.GroupBy(obj => obj.idx / columnCount) // Group the items into groups of "columnCount" items
		.Select(grp => grp.Select(obj => obj.str)) // Select the groups into an IEnumerable<IEnumerable<string>>
		.Where(strs => !strs.All(str => string.IsNullOrWhiteSpace(str))); // Filter empty rows;
	
	// Put the IEnumerable<IEnumerable<string>> into a string[,].
	var result = new string[withoutEmptyLines.Count(), columnCount];
	int rowIdx = 0;
	foreach (var row in withoutEmptyLines)
	{
		int colIdx = 0;
		foreach (var col in row)
		{
			result[rowIdx, colIdx++] = col;
		}
		rowIdx++;
	}
	
	return result;
}

    // Write out the column headers
	foreach (var columnName in columnNames)
	{
		Console.Write(columnName + ",");
	}
	Console.WriteLine();
	
    // Write out each element
	foreach (var item in data)
	{
		foreach (var columnName in columnNames)
		{
			Console.Write(item[columnName] + ",");
		}
		
		Console.WriteLine();
	}

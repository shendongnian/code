	using (var package = new ExcelPackage(excelFile))
	{
		var ws = package.Workbook.Worksheets.First();
        var lastRow = ws.Dimension.End.Row;
        var lastColumn = ws.Dimension.End.Column;
		Console.WriteLine($"Last Row: {lastRow}");
		Console.WriteLine($"Last Column: {lastColumn}");
	}

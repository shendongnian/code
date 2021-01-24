	using (var package = new ExcelPackage(excelFile))
	{
		var ws = package.Workbook.Worksheets.First();
		var lastRow = ws.Cells.Max(c => c.End.Row);
		var lastColumn = ws.Cells.Max(c => c.End.Column);
		Console.WriteLine($"Last Row: {lastRow}");
		Console.WriteLine($"Last Column: {lastColumn}");
	}

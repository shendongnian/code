    foreach (var row in columnNames)
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine(string.Join(",", columnNames));
		foreach (var dataRow in row.DataRowList)
		{
			IEnumerable<string> fields = dataRow.ItemArray.Select(field => string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
			sb.AppendLine(string.Join(",", fields));
		}
		string fileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + "\\" + row + "Breakout.csv";
		File.WriteAllText(fileName, sb.ToString());
	}

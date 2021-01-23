	var lines = new List<string>();
	string[] columnNames = dataTable.Columns
		.Cast<DataColumn>()
		.Select(column => column.ColumnName)
		.ToArray();
	var header = string.Join(",", columnNames.Select(name => $"\"{name}\""));
	lines.Add(header);
	var valueLines = dataTable.AsEnumerable()
		.Select(row => string.Join(",", row.ItemArray.Select(val => $"\"{val}\"")));
	lines.AddRange(valueLines);
	File.WriteAllLines("excel.csv", lines);

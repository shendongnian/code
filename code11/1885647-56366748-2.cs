	var engine = new FileHelperEngine<CSVDataFields>();
	
	var result = engine.ReadFile(@"c:\temp\some_source_file.txt");
	List<CSVDataFields> newRows = new List<CSVDataFields>();
	newRows.Add(result.First());
	result.Aggregate((a, b) =>
	{
		var diff = Math.Abs((a.Date - b.Date).Minutes);
		if (diff < 10)
		{
			return a;
		}
		else if (diff == 10)
		{
			newRows.Add(b);
			return b;
		}
		else
		{
			var newRow = new CSVDataFields()
			{
				Date = a.Date.AddMinutes(10),
				Value = (a.Value + b.Value) / 2
			};
			newRows.Add(newRow);
			return newRow;
		}
	});
	engine.WriteFile(@"C:\temp\destination_file_deduped.txt", newRows);

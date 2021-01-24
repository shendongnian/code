	string[] lines = System.IO.File.ReadAllLines(@filePath);
	for(int i = 0; i < lines.Length; i++)
	{
		string[] fields = lines[i].Split(',');
		if(RecordMatches(searchTerm, fields, positionOfSearchTerm))
		{
			Console.WriteLine("Record found");
			return fields;
		}
	}

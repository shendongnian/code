	string[] lines = System.IO.File.ReadAllLines(@filePath);
	for(int i = 0; i < lines.Length; i++)
	{
		string[] fields = lines[i].Split(',');
		RecordMatches(searchTerm, fields);
	}
    
    
    public static void RecordMatches(string searchTerm, string records[])
    {
	    foreach(string record in records)
	    {
		    if(record.Trim().Equals(searchTerm.Trim()))
		    {
			    Console.WriteLine(record);
		    }
	    }
    }

	string[] csvRows = System.IO.File.ReadAllLines(FullyQaulifiedFileName);
	string[] fields = null;
	List<string> lstFields;
	string field;
	bool quoteStarted = false;
	foreach (string csvRow in csvRows)
	{
		lstFields = new List<string>();
		field = "";
		for (int i = 0; i < csvRow.Length; i++)
		{
			tmp = csvRow.ElementAt(i).ToString();
			if(String.Compare(tmp,"\"")==0)
			{
				quoteStarted = !quoteStarted;
			}
			if (String.Compare(tmp, ";") == 0 && !quoteStarted)
			{
				lstFields.Add(field);
				field = "";
			}
			else if (String.Compare(tmp, "\"") != 0)
			{
				field += tmp;
			}
		}
		if(!string.IsNullOrEmpty(field))
		{
			lstFields.Add(field);
			field = "";
		}
	// This will hold values for each column for current row under processing
		fields = lstFields.ToArray(); 
	}

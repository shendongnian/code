	public DataTable ConvertCsvStringToDataTable(bool isFilePath,string CSVContent)
	{
		//CSVFilePathName = @"C:\test.csv";
		string[] Lines;
		if (isFilePath)
		{
			Lines = File.ReadAllLines(CSVContent);
		}
		else
		{
			Lines = CSVContent.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
		}
		string[] Fields;
		Fields = Lines[0].Split(new char[] { ',' });
		int Cols = Fields.GetLength(0);
		DataTable dt = new DataTable();
		//1st row must be column names; force lower case to ensure matching later on.
		for (int i = 0; i < Cols; i++)
			dt.Columns.Add(Fields[i].ToLower(), typeof(string));
		DataRow Row;
		for (int i = 1; i < Lines.GetLength(0); i++)
		{
			Fields = Lines[i].Split(new char[] { ',' });
			Row = dt.NewRow();
			for (int f = 0; f < Cols; f++)
				Row[f] = Fields[f];
			dt.Rows.Add(Row);
		}
		return dt;
	}

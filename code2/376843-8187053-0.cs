    StringBuilder consoleBuffer = new StringBuilder();
    using (CsvFileReader reader = new CsvFileReader(inputDataFile))
    {
		CsvRow row = new CsvRow();
		while (reader.ReadRow(row))
		{
			foreach (string s in row)
			{
			    consoleBuffer.Append(s);
				consoleBuffer.Append(" ");
			}
			consoleBuffer.Append(Environment.NewLine);
		}
		
		Console.WriteLine(consoleBuffer.ToString());
		// ... close the input data stream
		inputDataFile.Close();
	}

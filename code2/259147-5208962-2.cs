	public static void ProcessFile()
	{
		TextReader textReader = new StreamReader(@"C:\DEV\DATA\MyDataFile.txt");
		string s = textReader.ReadLine();  
		string col1 = s.Substring(9, 29).Trim();  
		
		s = textReader.ReadLine();  
		string col2 = s.Substring(9, 29).Trim();  
		
		s = textReader.ReadLine();  
		string col3 = s.Substring(9, 29).Trim();  
		
		s = textReader.ReadLine();  
		string col4 = s.Substring(9, 29).Trim();
		
		
		s = textReader.ReadLine();
		s = textReader.ReadLine();
		s = textReader.ReadLine();
		s = textReader.ReadLine();
		s = textReader.ReadLine();
		s = textReader.ReadLine();
		
		while ((s = textReader.ReadLine()).Trim() != "")
		{
		string column5 = s.Substring(0, 10).Trim();  
		string column6 = s.Substring(13, 23).Trim();  
		string column7 = s.Substring(25, 25).Trim();
		// Parse further columns here...
		// Insert record into the database
		}
	}

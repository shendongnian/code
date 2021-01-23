	public Classes.FileParameters ReadFromFile()
	{
		Classes.FileParameters Params;
		string directoryPath = Environment.CurrentDirectory.ToString();
		directoryPath = directoryPath.ToLower().Replace("\\bin\\debug", "\\Logs\\reminder.txt");
		var searchTarget = "searchString";
		foreach (var line in File.ReadLines(directoryPath))
		{
		   if (line.Contains(searchTarget))
			{
				// this will give you a string array of Comment, Name and Date
				// for every line that contains "searchString"
				string[] data = line.Split( new char[] { SepCharacter } );
				break; // then stop
			}
		}
		return null; 
	}

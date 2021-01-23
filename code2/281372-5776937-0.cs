	public bool WritetoFile(Classes.FileParameters Params)
	{
		string directoryPath = Environment.CurrentDirectory.ToString();
		directoryPath = directoryPath.ToLower().Replace("\\bin\\debug", "\\Logs\\reminder.txt");
		using(StreamWriter stream = File.AppendText(directoryPath))
		{
			stream.Write(Params.Comments.ToString());
			stream.Write(SepCharacter);
			stream.Write(directoryPath, Params.Name.ToString());
			stream.Write(SepCharacter);
			stream.WriteLine(directoryPath, Params.DateToSet.ToString());
		}
		return true;
	}
    
	public char SepCharacter { get{ return '\t'; } }

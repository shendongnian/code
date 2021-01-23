	using (StreamReader reader = new StreamReader(file))
	{
		string line;
		while((line = ReadToString(reader, "\r\n")) != null)
		{
			Console.WriteLine(line);
		}
    }

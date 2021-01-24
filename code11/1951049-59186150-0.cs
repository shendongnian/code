	try
	{
		using (StreamReader reader = new StreamReader(filename))
		{
			string[] lines= 
				reader.ReadToEnd() //Read the whole file
				.Trim() //Get rid of whitespace at the beginning and end of the file, no more random newlines at the end.
				.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries) //Separate each line AND remove any empty lines.
			;
			foreach (string _line in lines)
			{
				string line = _line.Trim();
				if (!line.Contains(','))
				{
					Console.Error.WriteLine("!!! Line did not contain comma for separation");
					Console.Error.WriteLine("!!!!!! " + line);
					continue; //Just go on to the next line.
				}
				string[] lineArray = line.Split(',');
				string answer = lineArray[1];
				string question = lineArray[0];
				questions.Add(question);
				answers.Add(answer);
			}
		}
	}
	catch (Exception e)
	{
		Console.WriteLine("File could not be read");
		Console.WriteLine(e.Message);
	}

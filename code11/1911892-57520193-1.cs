    using Microsoft.VisualBasic.FileIO;
...
    using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
	{
		using (var sr = new TextFieldParser(fileStream))
	    {
			while (!sr.EndOfData)
			{
				string[] row = sr.ReadFields();
				if (!DateTime.TryParse(row[0] as string, out DateTime date))
					continue;
				DateTime.TryParse(row[1] , out DateTime time);
				
					//etc
			}
		}
	}

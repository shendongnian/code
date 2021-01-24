    else if (File.Exists(path))
	{
		using (StreamWriter file = new StreamWriter("myfile.txt", append: true))
		{
			foreach (var entry in dictionary)
			{
				//        //file.WriteLine("[{0} {1}]", entry.Key, entry.Value);
				valueDic = valueDic + "|" + entry.Value.ToString();
			   
			}
			file.WriteLine(valueDic);
		}
	}

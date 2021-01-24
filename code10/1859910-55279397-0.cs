	static void ProcessFiles(string path)
	{
		foreach (string file in Directory.GetFiles(path))
		{
			JsonConvert.DeserializeXmlNode(File.ReadAllText(file)).Save(file + ".xml");
		}
	
		foreach (string directory in Directory.GetDirectories(path))
		{
			ProcessFiles(directory);
		}
	}

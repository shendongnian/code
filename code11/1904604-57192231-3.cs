    Dictionary<string, string> dictionary = new Dictionary<string, string>();
    dictionary = objeto.diccionary;
    string valueDic = "";
    string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"myfile.txt");
    using (StreamWriter file = new StreamWriter("myfile.txt", append: true))
    {
		foreach (var entry in dictionary)
		{
			valueDic = valueDic + "|" + entry.Value.ToString();
		}
		file.WriteLine(valueDic);
	}

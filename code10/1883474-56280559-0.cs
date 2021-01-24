    static void Main(string[] args)
	{
		Regex finderror = new Regex(@"(?<=\{)[^}]*(?=\})");
		DirectoryInfo id = new DirectoryInfo("E:\\student_copy\\text");
		FileInfo[] fiArrrr = id.GetFiles();
		foreach (FileInfo f in fiArrrr)
		{
			Console.WriteLine("File: " + f.FullName);
			string stuff = File.ReadAllText(f.FullName);
			Match errortext = finderror.Match(stuff);
			if (errortext.Success)
			{
				Console.WriteLine("Error Found:");
				Console.WriteLine(errortext.Value.Trim());
			}
			else
			{
				Console.WriteLine("No error for file.");
			}
		}
		Console.Write("Press Enter to quit");
		Console.ReadLine();
	}

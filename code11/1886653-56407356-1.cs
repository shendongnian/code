	// @"C:\Users\D205\Desktop\картинки\results.txt"
	private static String FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SomeFile.txt"); 
	private static Dictionary<string, int> AllNames()
	{
		return File
		  .ReadLines(FileName)
		  .Where(line => !string.IsNullOrWhiteSpace(line))
		  .Select(item => item.Split(' '))
		  .ToDictionary(items => items[0],
						items => int.Parse(items[1]));
	}
	private static void WriteNames(Dictionary<string, int> AllNames)
	{
		var lines = AllNames
		   .Select(kvp => kvp.Key + " " + kvp.Value.ToString())
		   .ToArray();
		File.WriteAllLines(FileName, lines);
	}
	private void button1_Click(object sender, EventArgs e)
	{
		var top5 = AllNames()
		   .OrderBy(pair => pair.Value)
		  .ThenBy(pair => pair.Key, StringComparer.Ordinal)
		  .Take(5);
		var tops = top5.ToArray();
		// ... your existing code to work with "tops" ...
		// write out the new file
		Dictionary<string, int> top5dict = new Dictionary<string, int>();
		foreach(var pair in top5)
		{
			top5dict.Add(pair.Key, pair.Value);
		}
		WriteNames(top5dict);
	}

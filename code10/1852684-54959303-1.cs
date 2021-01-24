private static void WriteToFile(string filePath, List<string>[] content)
{
	using (var fileWriter = new StreamWriter(filePath))
	{
		foreach (var line in content)
		{
			if (line == null)
			{
				continue;
			}
			for (var i = 0; i < line.Count; i++)
			{
				fileWriter.Write(line[i]);
				if (i != line.Count - 1)
				{
					fileWriter.Write(',');
				}
			}
			fileWriter.WriteLine();
		}
	}
}
private static void WriteToFileOneLiner(string filePath, List<string>[] content)
{
	File.WriteAllLines(filePath, content.Where(line => line != null).Select(line => string.Join(',', line)));
}
public static void Main(string[] args)
{
	List<string>[] phase2 = new List<string>[200];
	phase2[0] = new List<string>() { "Bob", "Complex", "B", "AOT", "Yes", "Yes", "Yes", "Yes", };
	phase2[1] = new List<string>() { "Joe", "Complex", "B", "AOT", "Yes", "Yes", "Yes", "Yes" };
	phase2[2] = new List<string>() { "Bill", "Complex", "A", "AOT", "Yes", "Yes", "Yes", "Yes" };
	WriteToFile(@"C:\Path\to\my\file.txt", phase2);
	WriteToFileOneLiner(@"C:\Path\to\my\file_oneliner.txt", phase2);
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.io.file
  [2]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/

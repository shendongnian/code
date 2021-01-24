cs
public class ScoreFileHandler
{
	private static string appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "YourAppName");
	private static string scoreFileName = "highscores.txt";
	private static string filePath = Path.Combine(appPath, scoreFileName);
	public string ReadFile()
	{
		if (!Directory.Exists(appPath))
		{
			Directory.CreateDirectory(appPath);
		}
		if (File.Exists(filePath))
		{
			return File.ReadAllText(filePath);
		}
		return string.Empty; // TODO - caller needs to handle this
	}
	public void WriteFile(string csvScoreData)
	{
		if (!Directory.Exists(appPath))
		{
			Directory.CreateDirectory(appPath);
		}
		File.WriteAllText(filePath, csvScoreData);
	}
}

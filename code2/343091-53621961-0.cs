    public static void ExtractFileNameFromUri(string URI, ref string parsedFileName, string fileNameStartDelimiter = "/", string fileNameEndDelimiter = "?")
{
	const int NOTFOUND = -1;
	try
	{
		int startParse = URI.LastIndexOf(fileNameStartDelimiter) + fileNameStartDelimiter.Length;
		if (startParse == NOTFOUND)
			return;
		int endParse = URI.IndexOf(fileNameEndDelimiter);
		if (endParse == NOTFOUND)
			endParse = URI.Length;
		parsedFileName = URI.Substring(startParse, (endParse - startParse));
	}
	catch (Exception e)
	{
		Console.WriteLine(e);
		return;
	}

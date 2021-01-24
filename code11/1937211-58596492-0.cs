	public void Validate(ILinkHandler handler, string filename)
	{
		Console.WriteLine($"Validating {filename}");
		var results = handler.Validate();
		SetUpResultsStatistics(results.Result, $"{filename}_Statistics");
		handler.WriteResults(filename);
	}

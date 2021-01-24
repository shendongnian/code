	static async Task Main(string[] args)
	{
		var tasks = new[]
		{
			Task.Run(() =>
			{
		        // Need to be awaited
		        var writer = WritingDatabase();
			}),
		
			Task.Run(() =>
			{
		        // Need to be awaited as well
		        var reader = ReadingDatabase();
			})
		};
		
		await Task.WhenAll(tasks);
	}

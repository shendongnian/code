	private async static Task<List<string>> source_list(List<string> links)
	{
		List<Task<string>> sources = new List<Task<string>>();
	
		for (int i = 0; i < links.Count; i++)
		{
			Task<string> _task = downloadsource(links[i]);
			Console.WriteLine("Downloading : " + i);
			sources.Add(_task);
		}
	
		return (await Task.WhenAll(sources)).ToList();
	}

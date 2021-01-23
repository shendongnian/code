    public IEnumerable<string> ProcessURLs(IEnumerable<string> URLs)
	{
		return URLs.AsParallel()
			.WithDegreeOfParallelism(10)
			.Where(url => testURL(url));
	}
	private bool testURL(string URL)
	{
		// some logic to determine true/false
		return false;
	}

	public async Task<string> GetData(int delay)
	{
		await Task.Delay(delay);
		return "complete";
	}
	public void StartGettingData()
	{
		GetData(5000).ContinueWith(t => CompleteGetData(t.Result), TaskScheduler.Current);
	}
	public void CompleteGetData(string message)
	{
		UpdateStatus(message);
	}

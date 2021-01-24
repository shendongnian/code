	static async Task Main(string[] args)
	{
		List<int> good = Process.GetProcesses().Select(x => x.Id).ToList();
		while (true)
		{
			await Task.Delay(TimeSpan.FromSeconds(1.0));
			List<int> bad = Process.GetProcesses().Select(x => x.Id).ToList();
			foreach (int pid in bad.Except(good))
			{
				Process.GetProcessById(pid).Kill();
				Console.WriteLine($"process {pid} dead.");
			}
		}
	}

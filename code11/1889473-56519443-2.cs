	async Task RunAsyncStreams()
	{
		await foreach (var n in RunAndPreserveOrderAsync(GenerateTasks(6)))
		{
			Console.WriteLine($"#{n} is returned");
		}
	}
	IEnumerable<Task<int>> GenerateTasks(int count)
	{
		return Enumerable.Range(1, count).Select(async n =>
		{
			await Task.Delay(new Random().Next(100, 1000));
			Console.WriteLine($"#{n} is complete");
			return n;
		});
	}
	async IAsyncEnumerable<int> RunAndPreserveOrderAsync(IEnumerable<Task<int>> tasks)
	{
		var queue = new Queue<Task<int>>(tasks);
		while (queue.Count > 0) yield return await queue.Dequeue();
	}

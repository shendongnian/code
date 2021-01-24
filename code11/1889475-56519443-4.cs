	/// Demonstrates Parallel Execution - Sequential Results with test tasks
	async Task RunAsyncStreams()
	{
		await foreach (var n in RunAndPreserveOrderAsync(GenerateTasks(6)))
		{
			Console.WriteLine($"#{n} is returned");
		}
	}
	/// Returns an enumerator that will produce a number of test tasks running
	/// for a random time.
	IEnumerable<Task<int>> GenerateTasks(int count)
	{
		return Enumerable.Range(1, count).Select(async n =>
		{
			await Task.Delay(new Random().Next(100, 1000));
			Console.WriteLine($"#{n} is complete");
			return n;
		});
	}
	/// Launches all tasks in order of enumeration, then waits for the results
	/// in the same order: Parallel Execution - Sequential Results.
	async IAsyncEnumerable<T> RunAndPreserveOrderAsync<T>(IEnumerable<Task<T>> tasks)
	{
		var queue = new Queue<Task<T>>(tasks);
		while (queue.Count > 0) yield return await queue.Dequeue();
	}

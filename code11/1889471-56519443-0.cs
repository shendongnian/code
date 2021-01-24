		async Task RunAsyncStream()
		{
			await foreach (var n in RunAndPreserveOrderAsync(GenerateTasks(6)))
			{
				Console.WriteLine($"#{n} is returned");
			}
		}
		readonly Random random_ = new Random();
		async Task<int> SimulateWork(int n)
		{
			await Task.Delay(random_.Next(100, 1000));
			Console.WriteLine($"#{n} is complete");
			return n;
		}
		IEnumerable<Task<int>> GenerateTasks(int count)
		{
			return Enumerable.Range(1, count).Select(SimulateWork);
		}
		async IAsyncEnumerable<int> RunAndPreserveOrderAsync(IEnumerable<Task<int>> tasks)
		{
			var queue = new Queue<Task<int>>(tasks);
			while(queue.Count > 0) yield return await queue.Dequeue();
		}

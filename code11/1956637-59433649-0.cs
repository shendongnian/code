async Task Main()
{
	var taskList = new[] { "Task 1", "Task 2" }
	.Select(SomethingAsync)
	.ToList();
	await AwaitAllTasks(taskList);
	Console.WriteLine("All tasks completed");
}
static async Task AwaitAllTasks(List<Task<string>> tasksList)
{
	/// Use a wait any loop to find any tasks that have completed
	/// Warning: this is O(N2) and will not scale for thousands of tasks
	while (tasksList.Count > 0)
	{
		var t = await Task.WhenAny(tasksList);
		tasksList.Remove(t);
		var theValue = await t;
		Console.WriteLine($"{theValue} completed.", theValue);
	}
}
static async Task<string> SomethingAsync(string theValue)
{
	await Task.Yield();
	Console.WriteLine(theValue);
	// Do a CPU bound activity
	for (int i = 0; i < 1000000; i++)
		;
	return theValue;
}
A couple of notes:
- There's no need for `AwaitAllTasks` to do `Task.Run()`. It's not CPU-intensive.
- C# now allows you to have an async Main method, so you can `await` instead of blocking on the main thread.

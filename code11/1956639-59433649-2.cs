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
Regarding this:
> They might not necessarily complete, as an exception might be thrown so I can't rely on a return code.
If an exception is thrown, the task will _complete_, but trying to `await` it will cause an exception to be thrown. So you might want to add a try/catch around the `await t`.
If it's possible that the task might literally never complete, you may want to use a cancellation token to avoid waiting for them indefinitely.
## Update ##
If you need to track specific information related to the task regardless of whether the task is successful, you'll need to use an appropriate collection, like a Dictionary, to maintain that correlation. For example:
async Task Main()
{
	var tasks = new[] { "Task 1", "Task 2", "Task 3" }
	.ToDictionary(name => SomethingAsync(name));
	await AwaitAllTasks(tasks);
	Console.WriteLine("All tasks completed");
}
static async Task AwaitAllTasks(IDictionary<Task, string> tasks)
{
	/// Use a wait any loop to find any tasks that have completed
	/// Warning: this is O(N2) and will not scale for thousands of tasks
	while (tasks.Count > 0)
	{
		var t = await Task.WhenAny(tasks.Keys);
		var theValue = tasks[t];
		tasks.Remove(t);
		try
		{
			await t;
			Console.WriteLine($"{theValue} completed.");
		}
		catch(Exception)
		{
			Console.WriteLine($"{theValue} had a failure.");
		}
	}
}
static async Task SomethingAsync(string theValue)
{
	await Task.Yield();
	Console.WriteLine(theValue);
	if(theValue == "Task 2"){
		throw new InvalidOperationException("Foo");
	}
	// Do a CPU bound activity
	for (int i = 0; i < 1000000; i++)
		;
}

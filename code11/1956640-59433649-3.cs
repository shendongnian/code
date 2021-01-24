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
## Update 2 ###
Another option is to avoid having a separate method for awaiting all the tasks individually, and just treat the action you want to take after each task as a continuation of each task. I usually find it best to think of a group of async tasks as a kind of data flow, where the result of each one can be passed into another operation, LINQ-style, until you're ready to bring their results all back together again.
async Task Main()
{
	var continuations = 
		from theValue in new[] { "Task 1", "Task 2", "Task 3" }
			// AsParallel() ensures the tasks are _begun_ in a multithreaded way.
			// Use it if SomethingAsync() might block the CPU for a while before 
            // yielding the thread.
			.AsParallel()
		let task = SomethingAsync(theValue)
		select ContinueSomething(task, theValue);
	try
	{
		await Task.WhenAll(continuations);
		Console.WriteLine("All tasks completed");
	}
	catch (Exception)
	{
		Console.WriteLine("Some tasks failed");
	}
}
static async Task ContinueSomething(Task somethingTask, string theValue)
{
	try
	{
		await somethingTask;
		Console.WriteLine($"{theValue} completed.");
	}
	catch (Exception)
	{
		Console.WriteLine($"{theValue} had a failure.");
	}
}
And of course, `async/await` is mostly syntactic sugar for things you could do otherwise. `ContinueSomething()` could be rewritten as:
static Task ContinueSomething(Task somethingTask, string theValue)
{
	return somethingTask.ContinueWith(t =>
	{
		if (t.IsFaulted)
		{
			Console.WriteLine($"{theValue} had a failure.");
		}
		else
		{
			Console.WriteLine($"{theValue} completed.");
		}
	});
}
Or you could even inline it into your original LINQ statement:
async Task Main()
{
	var continuations = 
		from theValue in new[] { "Task 1", "Task 2", "Task 3" }.AsParallel()
		let task = SomethingAsync(theValue)
		select task.ContinueWith(t =>
		{
			if (t.IsFaulted)
			{
				Console.WriteLine($"{theValue} had a failure.");
			}
			else
			{
				Console.WriteLine($"{theValue} completed.");
			}
		});
	await Task.WhenAll(continuations);
}
Of course, this all assumes your operations are inherently asynchronous. If your actual use case looks anything like the one you've posted, with almost entirely CPU-bound activity, you may want to skip the `async` stuff and just let `Parallel.ForEach()` take care of the parallelism for you:
void Main()
{
	Parallel.ForEach(new[] { "Task 1", "Task 2", "Task 3" }, theValue =>
	{
		try
		{
			SomethingAsync(theValue);
			Console.WriteLine($"{theValue} completed.");
		}
		catch (Exception)
		{
			Console.WriteLine($"{theValue} had a failure.");
		}
	});
	Console.WriteLine("All tasks completed");
}
static void SomethingAsync(string theValue)
{
	Console.WriteLine(theValue);
	if (theValue == "Task 2")
	{
		throw new InvalidOperationException("Foo");
	}
	// Do a CPU bound activity
	for (int i = 0; i < 1000000; i++)
		;
}
Point being: there are a lot of different ways to do the sort of thing you're trying to do, and which one is best will depend somewhat on specifics. 

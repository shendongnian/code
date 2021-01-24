cs
static async Task Main()
{
	var tasks = new Task<bool>[10];
	for (int i = 0; i < 10; i++)
	{
		tasks[i] = T();
	}
	await Task.WhenAll(tasks);
	for (int i = 0; i < tasks.Length; i++)
	{
		Console.WriteLine($"Task {i} result = {tasks[i].Result}");
	}
	Console.ReadKey();
}

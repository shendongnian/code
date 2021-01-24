csharp
public static TaskSynchronizer Synchronizer = new TaskSynchronizer();
public static async Task DoWork()
{
    await Task.Delay(100); // Some heavy work.
    Console.WriteLine("Work done!");
}
public static async Task WorkRequested()
{
    using (Synchronizer.Acquire(DoWork, out var task)) // Synchronize the call to work.
    {
        await task;
    }
}
static void Main(string[] args)
{
    var tasks = new List<Task>();
    for (var i = 0; i < 2; i++)
    {
        tasks.Add(WorkRequested());
    }
    Task.WaitAll(tasks.ToArray());
}
will output:
Work done!
EG: The async `DoWork` method has only be invoked once, even tho it has been invoked twice at the same time.

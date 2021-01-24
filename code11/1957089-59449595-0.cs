csharp
class Worker
{
    private List<Task> _tasks = new List<Task>();
    private readonly Stopwatch _stopwatch = new Stopwatch();
    // Start the stopwatch in the constructor or in some kind of a StartProcessing method.
    void OnTaskAdded(Task<int> task)
    {
        var taskWithContinuation = task.ContinueWith(t =>
            Console.WriteLine("Task {0} found to be completed at: {1}", t.Result, _stopwatch.Elapsed));
        _tasks.Add(taskWithContinuation);
    }
    async Task OnEndAsync()
    {
        // We're finishing work and there will be no more tasks, it's safe to await them all now.
        await Task.WhenAll(_tasks);
    }
}

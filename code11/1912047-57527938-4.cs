    static async Task DatabaseCallsAsync()
    {
        List<int> inputParameters = new List<int>();
        for (int i = 0; i < 100; i++)
        {
            inputParameters.Add(i);
        }
        await RunWithMaxDegreeOfConcurrency(10, inputParameters, x => DatabaseCallAsync($"Task {x}"));
    }
    static async Task DatabaseCallAsync(string taskName)
    {
        Console.WriteLine($"{taskName}: start");
        await Task.Delay(1000);
        Console.WriteLine($"{taskName}: finish");
    }
    public static async Task RunWithMaxDegreeOfConcurrency<T>(
         int maxDegreeOfConcurrency, IEnumerable<T> collection, Func<T, Task> taskFactory)
    {
        var activeTasks = new List<Task>(maxDegreeOfConcurrency);
        foreach (var task in collection.Select(taskFactory))
        {
            activeTasks.Add(task);
            if (activeTasks.Count == maxDegreeOfConcurrency)
            {
                await Task.WhenAny(activeTasks.ToArray());
                //observe exceptions here
                activeTasks.RemoveAll(t => t.IsCompleted); 
            }
        }
        await Task.WhenAll(activeTasks.ToArray()).ContinueWith(t => 
        {
            //observe exceptions in a manner consistent with the above   
        });
    }

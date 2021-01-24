    var taskFactories = new List<Func<Task>>();
    taskFactories.Add(() => TaskMethod("1"));
    taskFactories.Add(() => TaskMethod("2"));
    taskFactories.Add(() => TaskMethod("3"));
    var runningTasks = taskFactories.ToDictionary(factory => factory());
    while (runningTasks.Count > 0)
    {
        // Wait for something to happen, good or bad
        var completedTask = await Task.WhenAny(runningTasks.Keys);
        if (completedTask.IsFaulted) // Something bad happened
        {
            var factory = runningTasks[completedTask];
            var newTask = factory();
            runningTasks.Remove(completedTask);
            runningTasks.Add(newTask, factory);
        }
        else // A task just finished normally or was canceled
        {
            runningTasks.Remove(completedTask);
        }
    }

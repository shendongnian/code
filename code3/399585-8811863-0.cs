    Dictionary<int, Task> dict = new Dictionary<int, Task>();
    // Code to do first-time initialise of the dictionary
    ....
    // Subsequent refresh
    Task task;
    if (!dict.TryGet(id, out task))
    {
        task = new Task();
        task.Id = id;
        ...
        dict.Add(id, task);
    }

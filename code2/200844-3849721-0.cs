    while (true)
    {
        Task task = GetNextTask();
        if (task != null)
        {
             task.Execute();
        }
        else
        {
             Thread.Sleep(5000); // Avoid tight-looping
        }
    }

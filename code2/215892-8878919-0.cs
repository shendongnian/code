    foreach (ITask Task in Tasks)
    {
        Task.WaitHandle = CompletedEvent;
        new Thread(Task.Run).Start();
    }
    
    int TasksCount = Tasks.Count;
    for (int i = 0; i < TasksCount; i++)
        CompletedEvent.WaitOne();
    
    if (AllCompleted != null)
        AllCompleted(this, EventArgs.Empty);

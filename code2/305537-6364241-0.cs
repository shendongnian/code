    private readonly object _syncObj = new object();
    private readonly ConcurrentQueue<Action> _tasks = new ConcurrentQueue<Action>();
    public void QueueTask(Action task)
    {
        _tasks.Enqueue(task);
        Task.Factory.StartNew(ProcessQueue);
    }
    private void ProcessQueue()
    {
        while (_tasks.Count != 0 && Monitor.TryEnter(_syncObj))
        {
            try
            {
                Action action;
                while (_tasks.TryDequeue(out action))
                {
                    action();
                }
            }
            finally
            {
                Monitor.Exit(_syncObj);
            }
        }
    }

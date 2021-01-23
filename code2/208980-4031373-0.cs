    public void StartQueueHandler()
    { 
      new Thread(()=>StartWorker).Start();
    }
    
    private int[] Dequeue()
    {
      lock(_locker)
      {
        while(_taskQ.Count == 0) Monitor.Wait(_locker);
        return _taskQ.Dequeue();
      }
    }
    private void StartWorker(object obj)
    {
      while(_keepProcessing)
      { 
        //Handle thread abort or have another "shot down" mechanism.
        int[] work = Dequeue();
        //If work should be done in parallel without results.
        ThreadPool.QueueUserWorkItem(obj => DoWork(work));
        //If work should be done sequential according to the queue.
        DoWork(work);
      }
    }

        Dictionary<int, Thread> activeThreads = new Dictionary<int, Thread>();
        void LaunchWorkers()
        {
            foreach (var task in tasks)
            {
                Worker worker = new Worker(task, new WorkerDoneDelegate(ProcessResult));
                Thread thread = new Thread(worker.Done);
                thread.IsBackground = true;
                activeThreads.Add(thread.ManagedThreadId, thread);
            }
            lock (activeThreads)
            {
                activeThreads.Values.ToList().ForEach(n => n.Start());
            }
        }
        void ProcessResult(int threadId, TResult result)
        {
            lock (results)
            {
                results.Add(result);
            }
            lock (activeThreads)
            {
                activeThreads.Remove(threadId);
                // done when activeThreads.Count == 0
            }
        }
    }
    public delegate void WorkerDoneDelegate(object results);
    class Worker
    {
        public WorkerDoneDelegate Done;
        public void Work(Task task, WorkerDoneDelegate Done)
        {
            // process task
            Done(Thread.CurrentThread.ManagedThreadId, result);
        }
    }

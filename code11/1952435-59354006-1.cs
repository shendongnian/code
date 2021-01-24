    public class TaskQueue
    {
        private readonly SemaphoreSlim semaphore;
        private int pendingTasks;
        private int runningTasks;
    
        public TaskQueue(int maxConcurrencyLevel = 5)
        {
            semaphore = new SemaphoreSlim(maxConcurrencyLevel);
        }
    
        private async Task AddTask(Func<Task> task)
        {
            Interlocked.Increment(ref pendingTasks);
    
            await semaphore.WaitAsync();
    
            Interlocked.Decrement(ref pendingTasks);
            Interlocked.Increment(ref runningTasks);
    
            try
            {
                await task();
            }
            finally
            {
                Interlocked.Decrement(ref runningTasks);
    
                semaphore.Release();
            }
        }
    }

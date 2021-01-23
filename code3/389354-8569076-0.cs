    public sealed class SynchronizationContextFaultPropagatingTaskScheduler : TaskScheduler
    {
        #region Fields
        private SynchronizationContext synchronizationContext;
        private ConcurrentQueue<Task> taskQueue = new ConcurrentQueue<Task>();
        #endregion
        #region Constructors
        public SynchronizationContextFaultPropagatingTaskScheduler() : this(SynchronizationContext.Current)
        {
        }
        public SynchronizationContextFaultPropagatingTaskScheduler(SynchronizationContext synchronizationContext)
        {
            this.synchronizationContext = synchronizationContext;
        }
        #endregion
        #region Base class overrides
        protected override void QueueTask(Task task)
        {
            // Add a continuation to the task that will only execute if faulted and then post the exception back to the synchronization context
            task.ContinueWith(antecedent =>
                {
                    this.synchronizationContext.Post(sendState =>
                    {
                        throw (Exception)sendState;
                    },
                    antecedent.Exception);
                },
                TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously);
            // Enqueue this task
            this.taskQueue.Enqueue(task);
            // Make sure we're processing all queued tasks
            this.EnsureTasksAreBeingExecuted();
        }
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            // Excercise for the reader
            return false;
        }
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return this.taskQueue.ToArray();
        }
        #endregion
        #region Helper methods
        private void EnsureTasksAreBeingExecuted()
        {
            // Check if there's actually any tasks left at this point as it may have already been picked up by a previously executing thread pool thread (avoids queueing something up to the thread pool that will do nothing)
            if(this.taskQueue.Count > 0)
            {
                ThreadPool.UnsafeQueueUserWorkItem(_ =>
                {
                    Task nextTask;
                    // This thread pool thread will be used to drain the queue for as long as there are tasks in it
                    while(this.taskQueue.TryDequeue(out nextTask))
                    {
                        base.TryExecuteTask(nextTask);
                    }
                },
                null);
            }
        }
        #endregion
    }

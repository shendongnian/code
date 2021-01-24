    public class SingleThreadTaskScheduler : TaskScheduler, IDisposable
    {
        private readonly BlockingCollection<Task> _blockingCollection;
        public SingleThreadTaskScheduler()
        {
            _blockingCollection = new BlockingCollection<Task>();
            var thread = new Thread(() =>
            {
                foreach (var task in _blockingCollection.GetConsumingEnumerable())
                {
                    task.Wait(); // Causes the execution of TryExecuteTaskInline
                }
            })
            { IsBackground = true };
            thread.Start();
        }
        public override int MaximumConcurrencyLevel => 1;
        protected override void QueueTask(Task task) => _blockingCollection.Add(task);
        protected override bool TryExecuteTaskInline(Task task,
            bool taskWasPreviouslyQueued) => return TryExecuteTask(task);
        protected override IEnumerable<Task> GetScheduledTasks() => _blockingCollection;
        public void Dispose() => _blockingCollection.CompleteAdding();
    }

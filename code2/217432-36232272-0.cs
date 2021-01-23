    public class QueuedActions
    {
        private readonly object _internalSyncronizer = new object();
        private readonly ConcurrentQueue<Action> _actionsQueue = new ConcurrentQueue<Action>();
        public void Execute(Action action)
        {
            // ReSharper disable once InconsistentlySynchronizedField
            _actionsQueue.Enqueue(action);
            lock (_internalSyncronizer)
            {
                Action nextAction;
                if (_actionsQueue.TryDequeue(out nextAction))
                {
                    nextAction.Invoke();
                }
                else
                {
                    throw new Exception("Something is wrong. How come there is nothing in the queue?");
                }
            }
        }
    }

    public abstract class AwaitEnableThread : SynchronizationContext, IDisposable
    {
        // By JvanLangen.
        private class ActionWithState
        {
            public SendOrPostCallback Action { get; set; }
            public object State { get; set; }
        }
        private Task _mainTask;
        private int _mainTaskThreadId;
        private readonly ManualResetEvent _terminate = new ManualResetEvent(false);
        private readonly AutoResetEvent _actionAdded = new AutoResetEvent(false);
        private readonly ConcurrentQueue<ActionWithState> _actions = new ConcurrentQueue<ActionWithState>();
        private void TaskMethod()
        {
            _mainTaskThreadId = Thread.CurrentThread.ManagedThreadId;
            var waitHandles = new WaitHandle[] { _terminate, _actionAdded };
            SynchronizationContext.SetSynchronizationContext(this);
            while (WaitHandle.WaitAny(waitHandles) != 0)
                while (_actions.TryDequeue(out var actionWithState))
                    actionWithState.Action(actionWithState.State);
        }
        protected abstract void Run();
        protected bool Terminated => _terminate.WaitOne(0);
        public AwaitEnableThread()
        {
            _mainTask = Task.Run((Action)TaskMethod);
            _actions.Enqueue(new ActionWithState { Action = s => Run() });
            _actionAdded.Set();
        }
        public override void Post(SendOrPostCallback d, object state = null)
        {
            _actions.Enqueue(new ActionWithState { Action = d, State = state });
            _actionAdded.Set();
        }
        public void Post(Action action)
        {
            Post(s => action(), null);
        }
        public override void Send(SendOrPostCallback d, object state = null)
        {
            if (Thread.CurrentThread.ManagedThreadId != _mainTaskThreadId)
            {
                _actions.Enqueue(new ActionWithState { Action = d, State = state });
                _actionAdded.Set();
            }
            else
                d(state);
        }
        public void Send(Action action)
        {
            Send(s => action(), null);
        }
        public void Dispose()
        {
            _terminate.Set();
            _mainTask.Wait();
        }
    }

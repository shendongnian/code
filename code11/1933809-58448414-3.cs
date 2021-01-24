    // this is the base class which keeps track of a thread.
    public abstract class AwaitEnabledThread : SynchronizationContext, IDisposable
    {
        // By JvanLangen.
        // just a data holder to keep an action and a state together.
        private class ActionWithState
        {
            public SendOrPostCallback Action { get; set; }
            public object State { get; set; }
        }
        // main task
        private Task _mainTask;
        // a thread-id to compare if the send method was called from the this thread.
        private int _mainTaskThreadId;
        // to terminate this thread.
        private readonly ManualResetEvent _terminate = new ManualResetEvent(false);
        // an event so we can wait on it.
        private readonly AutoResetEvent _actionAdded = new AutoResetEvent(false);
        // the queue to hold the actions to execute on the thread.
        private readonly ConcurrentQueue<ActionWithState> _actions = new ConcurrentQueue<ActionWithState>();
        // main thread method.
        private void TaskMethod()
        {
            // get the thread id.
            _mainTaskThreadId = Thread.CurrentThread.ManagedThreadId;
            // an array containing wait handles (i love this trick)
            var waitHandles = new WaitHandle[] { _terminate, _actionAdded };
            // set the synchronizationcontext <--- the key of everything!
            SynchronizationContext.SetSynchronizationContext(this);
            // Wait on any handle and loop until the waithandle on index 0 is set.
            while (WaitHandle.WaitAny(waitHandles) != 0)
                // loop until the queue is empty
                while (_actions.TryDequeue(out var actionWithState))
                    // execute the action
                    actionWithState.Action(actionWithState.State);
        }
        protected abstract void Run();
        // Terminated, so you can terminate loops in derived classes.
        protected bool Terminated => _terminate.WaitOne(0);
        // constructor.
        public AwaitEnabledThread()
        {
            // setup the main task/thread
            _mainTask = Task.Run((Action)TaskMethod);
            // queue the abstract Run
            _actions.Enqueue(new ActionWithState { Action = s => Run() });
            _actionAdded.Set();
        }
        public override void Post(SendOrPostCallback d, object state = null)
        {
            // these are coming from the synchronization context, so you can queue
            // the action in your own queue
            // These are also used by the await/async stuff.
            _actions.Enqueue(new ActionWithState { Action = d, State = state });
            _actionAdded.Set();
        }
        public void Post(Action action)
        {
            Post(s => action(), null);
        }
        public override void Send(SendOrPostCallback d, object state = null)
        {
            // if the Send is called from this thread, execute it directly.
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
        // terminate and wait.
        public void Dispose()
        {
            _terminate.Set();
            _mainTask.Wait();
        }
    }

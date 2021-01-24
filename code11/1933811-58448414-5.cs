	Hello World! on thread: 1                           <br>
	18-10-2019 12:14:34| First on Thread: 4             <br>
	18-10-2019 12:14:34| Second on Thread: 4            <br>
	18-10-2019 12:14:35| Second on Thread: 4            <br>
	18-10-2019 12:14:35| First on Thread: 4             <br>
	18-10-2019 12:14:36| Second on Thread: 4            <br>
	18-10-2019 12:14:36| Second on Thread: 4            <br>
	18-10-2019 12:14:37| First on Thread: 4             <br>
	18-10-2019 12:14:37| Second on Thread: 4            <br>
	18-10-2019 12:14:37| Second on Thread: 4            <br>
	18-10-2019 12:14:38| First on Thread: 4             <br>
	18-10-2019 12:14:38| Second on Thread: 4            <br>
	18-10-2019 12:14:38| Second on Thread: 4            <br>
	18-10-2019 12:14:39| Second on Thread: 4            <br>
	18-10-2019 12:14:39| First on Thread: 4             <br>
---
    public class AwaitEnabledThread : SynchronizationContext, IDisposable
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
        public AwaitEnabledThread()
        {
            _mainTask = Task.Run((Action)TaskMethod);
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
        public bool Terminated => _terminate.WaitOne(0);
    }

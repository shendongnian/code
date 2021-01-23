    public class SomeClass
    {
        private readonly object _syncObj = new object();
        private readonly Thread _thread;
        private readonly Queue<Action> _queue = new Queue<Action>();
        private readonly ManualResetEvent _messageAccepted = new ManualResetEvent(false);
       
        public SomeClass()
        {
            _thread = new Thread(() =>
            {
                while (true)
                {
                    Action action;
                    while (TryDequeue(out action))
                    {
                        action();
                    }
                    _messageAccepted.WaitOne();
                }
            }) {IsBackground = true};
            _thread.Start();
        }
        private void Session_OnMessageAccepted(object sender, EventArgs e)
        {
            Action action = () =>{/* Do stuff */};
            Enqueue(action);
        }
        private void Enqueue(Action action)
        {
            lock (_syncObj)
            {
                _queue.Enqueue(action);
                _messageAccepted.Set();
            }
        }
        private bool TryDequeue(out Action action)
        {
            lock (_syncObj)
            {
                action = (_queue.Count != 0) ? _queue.Dequeue() : null;
                if (action == null) _messageAccepted.Reset();
                return (action != null);
            }
        }
    }

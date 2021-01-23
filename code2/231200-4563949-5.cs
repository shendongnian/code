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
                    Action operation;
                    while (TryDequeue(out operation))
                    {
                        operation();
                    }
                    _messageAccepted.WaitOne();
                }
            }) {IsBackground = true};
            _thread.Start();
        }
        private void Session_OnMessageAccepted(object sender, EventArgs e)
        {
            Action operation = () =>{/* Do stuff */};
            Enqueue(operation);
        }
        private void Enqueue(Action operation)
        {
            lock (_syncObj)
            {
                _queue.Enqueue(operation);
                _messageAccepted.Set();
            }
        }
        private bool TryDequeue(out Action operation)
        {
            lock (_syncObj)
            {
                operation = (_queue.Count != 0) ? _queue.Dequeue() : null;
                if (operation == null) _messageAccepted.Reset();
                return (operation != null);
            }
        }
    }

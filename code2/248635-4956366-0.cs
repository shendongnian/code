        public class MyEnumerator : IEnumerator<object>
        {
            private readonly Queue<object> _queue = new Queue<object>();
            private ManualResetEvent _event = new ManualResetEvent(false);
            public void Callback(object value)
            {
                lock (_queue)
                {
                    _queue.Enqueue(value);
                    _event.Set();
                }
            }
            public void Dispose()
            {
                
            }
            public bool MoveNext()
            {
                _event.WaitOne();
                lock (_queue)
                {
                    Current = _queue.Dequeue();
                    if (_queue.Count == 0)
                        _event.Reset();
                }
                return true;
            }
            public void Reset()
            {
                _queue.Clear();
            }
            public object Current { get; private set; }
            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
        static void Main(string[] args)
        {
            var enumerator = new MyEnumerator();
            Scan(enumerator.Callback);
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }

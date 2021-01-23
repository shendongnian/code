        public class ThrottledQueue<T> : IDisposable where T : class
    {
        readonly object _locker = new object();
        readonly List<Thread> _workers;
        readonly Queue<T> _taskQueue = new Queue<T>();
        readonly Action<T> _dequeueAction;
        readonly TimeSpan _throttleTimespan;
        readonly Thread _workerThread;
        /// <summary>
        /// Initializes a new instance of the <see cref="SuperQueue{T}"/> class.
        /// </summary>
        /// <param name="millisecondInterval">interval between throttled thread invokation</param>
        /// <param name="dequeueAction">The dequeue action.</param>
        public ThrottledQueue(int millisecondInterval, Action<T> dequeueAction)
        {
            _dequeueAction = dequeueAction;
            // Create and start a separate thread for each worker
            _workerThread = new Thread(Consume) { IsBackground = true, Name = string.Format("ThrottledQueue worker") };
            _workerThread.Start();
            _throttleTimespan = new TimeSpan(0,0,0,0,millisecondInterval);
        }
        /// <summary>
        /// Enqueues the task.
        /// </summary>
        /// <param name="task">The task.</param>
        public void EnqueueTask(T task)
        {
            lock (_locker)
            {
                _taskQueue.Enqueue(task);
            }
        }
        /// <summary>
        /// Consumes this instance.
        /// </summary>
        void Consume()
        {
            while (true)
            {
                T item = default(T);
                lock (_locker)
                {
                    Monitor.Wait(_locker, _throttleTimespan);
                    if (_taskQueue.Count != 0) 
                        item = _taskQueue.Dequeue();
                }
                if (item == null) return;
                // run actual method
                _dequeueAction(item);
            }
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Enqueue one null task per worker to make each exit.
            EnqueueTask(null);
            _workerThread.Join();
        }
    }

    public class SuperQueue<T> : IDisposable where T : class
    {
        readonly object _locker = new object();
        readonly List<Thread> _workers;
        readonly Queue<T> _taskQueue = new Queue<T>();
        readonly Action<T> _dequeueAction;
        /// <summary>
        /// Initializes a new instance of the <see cref="SuperQueue{T}"/> class.
        /// </summary>
        /// <param name="workerCount">The worker count.</param>
        /// <param name="dequeueAction">The dequeue action.</param>
        public SuperQueue(int workerCount, Action<T> dequeueAction)
        {
            _dequeueAction = dequeueAction;
            _workers = new List<Thread>(workerCount);
            // Create and start a separate thread for each worker
            for (int i = 0; i < workerCount; i++)
            {
                Thread t = new Thread(Consume) { IsBackground = true, Name = string.Format("SuperQueue worker {0}",i )};
                _workers.Add(t);
                t.Start();
            }
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
                Monitor.PulseAll(_locker);
            }
        }
        /// <summary>
        /// Consumes this instance.
        /// </summary>
        void Consume()
        {
            while (true)
            {
                T item;
                lock (_locker)
                {
                    while (_taskQueue.Count == 0) Monitor.Wait(_locker);
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
            _workers.ForEach(thread => EnqueueTask(null));
    
            _workers.ForEach(thread => thread.Join());
    
        }
    }

    public class Worker<T>
    {
        private readonly Object _lock = new Object();
        private readonly Queue<T> _queuedItems = new Queue<T>();
        private readonly AutoResetEvent _itemReadyEvt = new AutoResetEvent(false);
        private readonly IProducer<T> _producer;
        private readonly IConsumer<T> _consumer;
        private volatile bool _ending = false;
        private Thread _workerThread;
        public Worker(IProducer<T> producer, IConsumer<T> consumer)
        {
            _producer = producer;
            _consumer = consumer;
        }
        public void Start(ThreadPriority priority)
        {
            _producer.ItemProduced += Producer_ItemProduced;
            _ending = false;
            // start a new thread
            _workerThread = new Thread(new ThreadStart(WorkerLoop));
            _workerThread.IsBackground = true;
            _workerThread.Priority = priority;
            _workerThread.Start();
        } 
        public void Stop()
        {
            _producer.ItemProduced += Producer_ItemProduced;
            _ending = true;
            // signal the consumer, in case it is idle
            _itemReadyEvt.Set();
            _workerThread.Join();
        }
        private void Producer_ItemProduced
             (object sender, ProducedItemEventArgs<T> e)
        {
            lock (_lock) { _queuedItems.Enqueue(e.Item); }
            // notify consumer thread
            _itemReadyEvt.Set();
        }
        private void WorkerLoop()
        {
            while (!_ending)
            {
                _itemReadyEvt.WaitOne(-1, false);
                T singleItem = default(T);
                lock (_lock)
                {
                   if (_queuedItems.Count > 0)
                   {
                       singleItem = _queuedItems.Dequeue();
                   }
                }
                while (singleItem != null)
                {
                    try
                    {
                        _consumer.ConsumeItem(singleItem);
                    }
                    catch (Exception ex)
                    {
                        // handle exception, fire an event
                        // or something. Otherwise this
                        // worker thread will die and you
                        // will have no idea what happened
                    }
                    lock (_lock)
                    {
                        if (_queuedItems.Count > 0)
                        {
                            singleItem = _queuedItems.Dequeue();
                        }
                    }
                }
             }
        } // WorkerLoop
    } // Worker

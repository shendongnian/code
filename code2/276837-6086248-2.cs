    public class Controller
    {
        private object _lock1;
        private object _lock2;
        private object _lock3;
        private Thread _worker1;
        private Thread _worker2;
        private Thread _worker3;
        public Controller()
        {
            _lock1 = new object();
            _lock2 = new object();
            _lock3 = new object();
            _worker1 = new Thread(ExecuteWorker, _lock1);
            _worker2 = new Thread(ExecuteWorker, _lock2);
            _worker3 = new Thread(ExecuteWorker, _lock3);
            lock (_lock1)
            {
                _worker1.Start();
                Monitor.Wait(_lock1);
            }
            lock (_lock2)
            {
                _worker2.Start();
                Monitor.Wait(_lock2);
            }
            lock (_lock3)
            {
                _worker3.Start();
                Monitor.Wait(_lock3);
            }
        }
        public void Execute()
        {
            // Perform database logic, assuming decremented values are stored.
            int value1 = DecrementValueFromDB();
            int value2 = DecrementValueFromDB();
            int value3 = DecrementValueFromDB();
            
            if (value1 == 0)
            {
                lock (_lock1)
                {
                    Monitor.Pulse(_lock1);
                }
            }
            if (value2 == 0)
            {
                lock (_lock2)
                {
                    Monitor.Pulse(_lock2);
                }
            }
            /// ... repeat for third value
            //
        }
    }

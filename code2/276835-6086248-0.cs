    public class Controller
    {
        private object _lock1;
        private object _lock2;
        private object _lock3;
        private Worker _worker1;
        private Worker _worker2;
        private Worker _worker3;
        public Controller()
        {
            _lock1 = new object();
            _lock2 = new object();
            _lock3 = new object();
            _worker1 = new Worker();
            _worker2 = new Worker();
            _worker3 = new Worker();
        }
        public void Execute()
        {
            // Perform database logic
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

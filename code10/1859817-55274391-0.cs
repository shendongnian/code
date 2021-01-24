    class CountToBillionWrapper
    {
        private readonly int _workerId;
        public CountToBillionWrapper(int workerId)
        {
            _workerId = workerId;
        }
        public int CountToBillion()
        {
            // do whatever, using the _workerId field as if it had been passed to the method
        }
    }

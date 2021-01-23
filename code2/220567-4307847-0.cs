    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    class MyObject: IMyObject
    {
        private readonly object lockObject = new object();
        public string Reload()
        {
            lock (lockObject)
            {
                // Reload stuff
            }
        }
        public string Read1()
        {
            lock (lockObject)
            {
                // Read1 stuff
            }
        }
        public string Read2()
        {
            lock (lockObject)
            {
                // Read2 stuff
            }
        }
    }

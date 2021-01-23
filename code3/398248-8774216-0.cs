        private static object SynchronizationObject = new Object();
        public void PerformSomeCriticalWork()
        {
            lock (SynchronizationObject)
            {
                // do some critical work
            }
        }

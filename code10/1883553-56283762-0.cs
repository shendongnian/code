    public class Semaphore2
    {
        public int CurrentCount { get; private set; }
        private readonly object _locker = new object();
        public Semaphore2(int initialCount)
        {
            CurrentCount = initialCount;
        }
        public void Wait(int count)
        {
            lock (_locker)
            {
                while (CurrentCount < count)
                {
                    Monitor.Wait(_locker);
                }
                CurrentCount -= count;
            }
        }
        public void Release(int count)
        {
            lock (_locker)
            {
                CurrentCount += count;
                Monitor.PulseAll(_locker);
            }
        }
    }

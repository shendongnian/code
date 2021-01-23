    public class Semaphore
    {
        private int count = 0;
        private int limit = 0;
        private object locker = new object();
    
        public Semaphore(int initialCount, int maximumCount)
        {
            count = initialCount;
            limit = maximumCount;
        }
    
        public void Wait()
        {
            lock (locker)
            {
                while (count == 0) 
                {
                    Monitor.Wait(locker);
                }
                count--;
            }
        }
    
        public bool TryRelease()
        {
            lock (locker)
            {
                if (count < limit)
                {
                    count++;
                    Monitor.PulseAll(locker);
                    return true;
                }
                return false;
            }
        }
    }

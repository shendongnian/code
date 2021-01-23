    public class MySemaphore
    {
        private int size; // number of occupied resources
        private readonly int capacity; // total capacity
        public MySemaphore(int size, int capacity)
        {
            this.size = size;
            this.capacity = capacity;
        }
        public void Lock(int count) // acquire "count" resources
        {
            lock(this)
            {
                while(capacity - size < count)
                {
                    Monitor.Wait(this);
                }
                size += count;
            }
        }        
        public void Unlock(int count) // release "count" resources
        {
            lock(this)
            {
                size -= count;
                Monitor.PulseAll(this);
            }
        }
    }

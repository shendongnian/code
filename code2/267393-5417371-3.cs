    public class WatchedVariable<T>
        where T : class
    {
        private volatile T value;
        private object valueLock = new object();
        public T Value
        {
            get { return value; }
            set
            {
                lock (valueLock)
                {
                    this.value = value;
                    Monitor.PulseAll(valueLock);  // all waiting threads will resume once we release valueLock
                }
            }
        }
        public T WaitForChange(T fromValue)
        {
            lock (valueLock)
            {
                while (true)
                {
                    T nextValue = value;
                    if (nextValue != fromValue) return nextValue;  // no race condition here: PulseAll can only be reached once we hit Wait()
                    Monitor.Wait(valueLock);  // wait for a changed pulse
                }
            }
        }
        public WatchedVariable(T initValue)
        {
            value = initValue;
        }
    }

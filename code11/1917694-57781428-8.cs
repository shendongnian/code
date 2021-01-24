    public class JustOne
    {
        private Object _lock = new Object();
    
        public bool Do(Action action)
        {
            bool lockTaken = false;
            try
            {
                Monitor.TryEnter(_lock, ref lockTaken);
                if (lockTaken)
                {
                    action();
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(_lock);
                }
            }
    
            return true;
        }
    }

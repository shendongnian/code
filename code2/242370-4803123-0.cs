    class Synchronized
    {
        object lockObj = new object();
        int counter = 100;
  
        public void Decrement()
        {
            lock (this.lockObj)
            {
                this.counter--;
            }
        }
    
        public int IsZero()
        {
            lock (this.lockObj)
            {
                return this.counter == 0;
            }
        }
    }

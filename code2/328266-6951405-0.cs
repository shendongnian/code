    interface Dequeable
    {
        public int dequed();
    }
    class ConcurrentQueueImpl extends ConcurrentQueue
    {
        ..................
        .................
        @override
        public Dequeable deque()
        {
            Dequeable obj=...........;
            **if(obj.dequed()>=10)**
            {
                // dispose off obj
                return null;
            }
            return obj;
        }
    }
    class SampleDequeableClass implements Dequeable
    {
        private int dequedCounter=0;
        public int dequed()
        {
            dequedCounter++;
            if(dequedCounter>=10)
            {
                // log off this object...
            }
        }
    }

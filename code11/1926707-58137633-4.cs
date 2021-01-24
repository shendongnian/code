    public class ArrayPool<T>
    {
        public int Size { get => pool.Count(); }
        public int maxSize = 3;
        public int circulingObjectCount = 0;
        private Queue<T> pool = new Queue<T>();
        private Func<T> constructorFunc;
        public ArrayPool(Func<T> constructorFunc) {
            this.constructorFunc = constructorFunc;
        }
        public Task Use(Func<T, Task> action)
        {
            T item = GetNextItem(); //DeQueue the item
            var t = action(item);
            t.ContinueWith(task => pool.Enqueue(item)); //Requeue the item
            return t;
        }
        private T GetNextItem()
        {
            //Create new object if pool is empty and not reached maxSize
            if (pool.Count == 0 && circulingObjectCount < maxSize)
            {
                T item = constructorFunc();
                circulingObjectCount++;
                Console.WriteLine("Pool empty, adding new item");
                return item;
            }
            //Wait for Queue to have at least 1 item
            WaitForReturns();
            return pool.Dequeue();
        }
        private void WaitForReturns()
        {
            long timeouts = 60000;
            while (pool.Count == 0 && timeouts > 0) { timeouts--; System.Threading.Thread.Sleep(1); }
            if(timeouts == 0)
            {
                throw new Exception("Wait timed-out");
            }
        }
    }

    class Program
    {
        ConcurrentDictionary<double, Store> _StoreQueue = new ConcurrentDictionary<double, Store>();
        static void Main(string[] args)
        {
            var T = 17d;
            // try to add if not exit the store with 17
            _StoreQueue.GetOrAdd(T, new Store(T));
        }
        public class Store
        {
            public double TimeStamp { get; set; }
            public Store(double timeStamp)
            {
                TimeStamp = timeStamp;
            }
        }
    }

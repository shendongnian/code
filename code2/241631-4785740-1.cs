    class Program
    {
        private static object list1_lock = new object();
        private const int collSize = 1000;
    
        static void Main()
        {
            ConcurrentBagTest();
            LockCollTest();
        }
    
        private static void ConcurrentBagTest()
        {
            var bag1 = new ConcurrentBag<int>();
            var stopWatch = Stopwatch.StartNew();
            Task.WaitAll(Enumerable.Range(1, collSize).Select(x => Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5);
                bag1.Add(x);
            })).ToArray());
            stopWatch.Stop();
            Console.WriteLine("Elapsed Time = {0}", stopWatch.Elapsed.TotalSeconds);
        }
    
        private static void LockCollTest()
        {
            var lst1 = new List<int>(collSize);
            var stopWatch = Stopwatch.StartNew();
            Task.WaitAll(Enumerable.Range(1, collSize).Select(x => Task.Factory.StartNew(() =>
            {
                lock (list1_lock)
                {
                    Thread.Sleep(5);
                    lst1.Add(x);
                }
            })).ToArray());
            stopWatch.Stop();
            Console.WriteLine("Elapsed = {0}", stopWatch.Elapsed.TotalSeconds);
        }
    }

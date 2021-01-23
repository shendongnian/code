    using System.Threading.Tasks;
    class Program
    {
        public const int count = 3000;
        static ConcurrentBag<int> bag = new ConcurrentBag<int>();
        static void DoWork(int i)
        {
            bag.Add(i);
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Stopwatch s = new Stopwatch();
                s.Start();
                Parallel.For(0, count + 1, DoWork);
                s.Stop();
                Console.WriteLine("\n Elapsed: " + s.Elapsed.ToString());
                Console.WriteLine("Expected: {0}", count + 1);
                Console.WriteLine("count: {0}", bag.Count);
                Console.ReadKey();
                bag = new ConcurrentBag<int>();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            for (int i = 1; i <= 1000000; i++)
            {
                numbers.Add(i);
            }
            for (int i = 1; i <= 100; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                ExecuteFirst(ref stopwatch, ref numbers);
                stopwatch.Reset();
                ExecuteLast(ref stopwatch, ref numbers);
            }
            for (int i = 1; i <= 100; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                ExecuteLast(ref stopwatch, ref numbers);
                stopwatch.Reset();
                ExecuteFirst(ref stopwatch, ref numbers);
            }
        }
        private static void ExecuteFirst(ref Stopwatch stopwatch, ref List<int> numbers)
        {
            stopwatch.Start();
            int first = numbers.FirstOrDefault(x => x == 500000);
            stopwatch.Stop();
            Console.WriteLine("First: " + stopwatch.Elapsed);
        }
        private static void ExecuteLast(ref Stopwatch stopwatch, ref List<int> numbers)
        {
            stopwatch.Start();
            int last = numbers.LastOrDefault(x => x == 500000);
            stopwatch.Stop();
            Console.WriteLine("Last: " + stopwatch.Elapsed);
        }
    }

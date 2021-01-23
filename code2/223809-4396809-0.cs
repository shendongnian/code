    class Program
    {
        public static IEnumerable<int> TestData()
        {
            while (true)
                yield return 5;
        }
    
        public static IEnumerable<int> AndrewHare(IEnumerable<int> xs)
        {
            return xs.TakeWhile(i => i != 5)
                     .Where(j => j == 1);
        }
    
        public static IEnumerable<int> Saeed(IEnumerable<int> xs)
        {
            bool find5 = false;
            return xs.Where(p => p == 1 && !(find5 = (p == 5) ? true : find5));
        }
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            
            watch.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                foreach (var x in AndrewHare(TestData())) ;
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            watch.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                foreach (var x in Saeed(TestData())) ;
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            
            Console.ReadKey();
        }
    }

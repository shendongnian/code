        static List<int> TestList;
        const int ThreadCount = 10;
        const int IterationsA = 1000;
            static int count = 0;
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    TestList = new List<int>();
                    List<Thread> threads = new List<Thread>();
                    for (var x = 0; x < ThreadCount; x++)
                    {
                        var t = new Thread(() => AddToList(x));
                        t.Start();
                        threads.Add(t);
                    }
                    foreach (var t in threads)
                        t.Join();
                    var b = TestList.Any(i => i == 1);
                    Console.WriteLine("Pass " + DateTime.Now.ToString("hh:mm:ss.fff"));
                    count += 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine($"Failed after {count} attempts");
            }
            Console.ReadLine();
        }
        static void AddToList(int seed)
        {
            try
            {
                var random = new Random(seed);
                for (var x = 0; x < IterationsA; x++)
                {
                    TestList.Add(random.Next());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine($"Failed after {count} attempts");
                Console.ReadLine();
            }
        }

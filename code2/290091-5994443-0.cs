        private static void Main(string[] args)
        {
            ICollection<string> collectionA = new List<string>();
            ICollection<string> collectionB = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                string randomString = Path.GetRandomFileName();
                collectionA.Add(randomString);
                collectionA.Add(randomString);
                collectionB.Add(randomString);
                collectionB.Add(randomString);
            }
            Stopwatch testA = new Stopwatch();
            testA.Start();
            MethodA(collectionA, collectionB);
            testA.Stop();
            Stopwatch testB = new Stopwatch();
            testB.Start();
            MethodB(collectionA, collectionB);
            testB.Stop();
            Console.WriteLine("MethodA: {0}ms", testA.ElapsedMilliseconds);
            Console.WriteLine("MethodB: {0}ms", testB.ElapsedMilliseconds);
            Console.ReadLine();
        }
        private static void MethodA(ICollection<string> collectionA, ICollection<string> collectionB)
        {
            for (int i = 0; i < 10000; i++)
            {
                var result = collectionA.Union(collectionB);
            }
        }
        private static void MethodB(ICollection<string> collectionA, ICollection<string> collectionB)
        {
            for (int i = 0; i < 10000; i++)
            {
                var result = new HashSet<string>(collectionA);
                foreach (string s in collectionB)
                {
                    result.Add(s);
                }
            }
        }

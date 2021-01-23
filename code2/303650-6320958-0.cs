    class Program
    {
        static void Main()
        {
            new InstanceField().RunTests();
            new StaticFieldStaticInitializer().RunTests();
            new StaticFieldNoInitializer().RunTests();
            Console.ReadLine();
        }
        class InstanceField
        {
            public bool[] arr= new bool[1024];
            public void RunTests()
            {
                var watch = Stopwatch.StartNew();
                int count = 0;
                for (int i = 0; i < 500000; i++)
                {
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j]) count++;
                    }
                }
                watch.Stop();
                Console.WriteLine("{0}: {1}ms", GetType().Name, watch.ElapsedMilliseconds);
            }
        }
        class StaticFieldStaticInitializer
        {
            public static bool[] arr = new bool[1024];
            public void RunTests()
            {
                var watch = Stopwatch.StartNew();
                int count = 0;
                for (int i = 0; i < 500000; i++)
                {
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j]) count++;
                    }
                }
                watch.Stop();
                Console.WriteLine("{0}: {1}ms", GetType().Name, watch.ElapsedMilliseconds);
            }
        }
        class StaticFieldNoInitializer
        {
            public static bool[] arr;
            public void RunTests()
            {                
                arr = new bool[1024];
                var watch = Stopwatch.StartNew();
                int count = 0;
                for (int i = 0; i < 500000; i++)
                {
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j]) count++;
                    }
                }
                watch.Stop();
                Console.WriteLine("{0}: {1}ms", GetType().Name, watch.ElapsedMilliseconds);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mainTask = MainAsync(args);
            mainTask.GetAwaiter().GetResult();
        }
        static async Task MainAsync(string[] args)
        {
            var task1 = Method1();
            var task2 = Method2();
            var task3 = Method3();
            await Task.WhenAll(task1, task2, task3);
            Console.ReadLine();
        }
        public static async Task<long> Method1()
        {
            var returnValue = 0l;
            for (long i = 0; i < 5; i++)
            {
                Console.WriteLine($"Method 1 : {i}");
                returnValue += i;
            }
            return await Task.FromResult(returnValue);
        }
        public static async Task<long> Method2()
        {
            var returnValue = 0l;
            for (long i = 0; i < 5; i++)
            {
                Console.WriteLine($"Method 2 : {i}");
                returnValue += i;
            }
            return await Task.FromResult(returnValue);
        }
        public static async Task<long> Method3()
        {
            var returnValue = 0l;
            for (long i = 0; i < 5; i++)
            {
                Console.WriteLine($"Method 3 : {i}");
                returnValue += i;
            }
            return await Task.FromResult(returnValue);
        }
    }

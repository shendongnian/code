    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] arr = new int[100];
            arr = arr.Select(i => r.Next(-30, 30)).ToArray();            
            Profile(Test0, arr, 20);
            Profile(Test1, arr, 20);
            Profile(Test2, arr, 20);
            Console.WriteLine("Test0: {0} ms", Profile(Test1, arr, 100).TotalMilliseconds);
            Console.WriteLine("Test1: {0} ms", Profile(Test1, arr, 100).TotalMilliseconds);
            Console.WriteLine("Test2: {0} ms", Profile(Test2, arr, 100).TotalMilliseconds);
            Console.ReadLine();
        }
        static void Test0(int[] a)
        {
            int N = a.Length;
            int total = 0;
            for (int i = 0; i < N; ++i)
                for (int j = i + 1; j < N; ++j)
                    for (int k = j + 1; k < N; ++k)
                        if (a[i] + a[j] + a[k] == 30)
                            total++;
        }
        static void Test1(int[] a)
        {
            int N = a.Length;
            int total = 0;
            Object locker = new object();
            Parallel.For(0, N, i => Parallel.For(i+1, N, j => Parallel.For(j+1, N, k =>
            {
                if (a[i] + a[j] + a[k] == 30)
                    lock(locker)
                        total++;
            })));
        }
        static void Test2(int[] a)
        {
            int N = a.Length;
            int total = 0;
            Object locker = new object();
            Parallel.For(0, N, i => 
            {
                for (int j = i + 1; j < N; ++j)
                    for (int k = j + 1; k < N; ++k)
                        if (a[i] + a[j] + a[k] == 30)
                            lock(locker) 
                                total++;
            });
        }
    }

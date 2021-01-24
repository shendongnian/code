    class Program
    {
        static int Fib(int num)
        {
            return RecursiveTask<int, int>.Create((t, n) =>
            {
                if (n == 0) return 0;
                if (n == 1) return 1;
                return t.Run(n - 1) + t.Run(n - 2);
            }).Run(num);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Fib(7));
            Console.WriteLine(Fib(100000));
        }
    }

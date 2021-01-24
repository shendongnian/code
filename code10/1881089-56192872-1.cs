    class Program
    {
        static RecursiveTask<int> Fib(int n, int a, int b)
        {
            if (n == 0) return a;
            if (n == 1) return b;
            return RecursiveTask<int>.FromFunc(() => Fib(n - 1, b, a + b));
        }
        static RecursiveTask<int> Factorial(int n, int a)
        {
            if (n == 0) return a;
            return RecursiveTask<int>.FromFunc(() => Factorial(n - 1, n * a));
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(5, 1).Result);
            Console.WriteLine(Fib(100000, 0, 1).Result);
        }
    }

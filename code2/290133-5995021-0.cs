    public delegate T Sum<T>(T a, T b);
    
    class Program
    {
        static void Main(string[] args)
        {
            int sum = Test.Sum(new[] {1, 2, 3}, (x, y) => x + y);
        }
    }
    public static class Test
    {
        public static int Sum<T>(IEnumerable<T> sequence, Sum<T> summator)
        {
            // Do work
        }
    }

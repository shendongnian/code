    static class Program
    {
        public static HashSet<T> ToSet<T>(this IEnumerable<T> collection)
        {
            return new HashSet<T>(collection);
        }
        public static HashSet<T> Subtract<T>(this HashSet<T> set, IEnumerable<T> other)
        {
            var clone = set.ToSet();
            clone.ExceptWith(other);
            return clone;
        }
        static void Main(string[] args)
        {
            var A = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var B = new HashSet<int> { 2, 4, 6, 8, 10 };
            var sw = new Stopwatch();
            sw.Restart();
            for (int i = 0; i < 1000000; ++i)
            {
                var C = A.Except(B).ToSet();
            }
            sw.Stop();
            Console.WriteLine("Linq: {0} ms", sw.ElapsedMilliseconds);
            sw.Restart();
            for (int i = 0; i < 1000000; ++i)
            {
                var C = A.Subtract(B);
            }
            sw.Stop();
            Console.WriteLine("Native: {0} ms", sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }

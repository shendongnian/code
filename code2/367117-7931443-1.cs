    static class Program
    {
        static void Main()
        {
            byte[, ,] a = new byte[2, 10, 10];
            ForEach(a, delegate(byte b)
            {
                Console.WriteLine(b);
            });
        }
        private static void ForEach<T>(T[, ,] a, Action<T> action)
        {
            foreach (var item in a)
            {
                action(item);
            }
        }
    }

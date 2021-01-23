    class Program
    {
        private static void Swap(ref int a, ref int b)
        {
            int.TryParse((a ^ b).ToString(), out a);
            int.TryParse((a ^ b).ToString(), out b);
            int.TryParse((a ^ b).ToString(), out a);
        }
        static void Main(string[] args)
        {
            int a = 42;
            int b = 123;
            Console.WriteLine("a:{0}\nb:{1}", a, b);
            Swap(ref a, ref b);
            Console.WriteLine("a:{0}\nb:{1}", a, b);
        }
    }

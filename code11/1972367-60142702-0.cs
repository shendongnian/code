    using System;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            Implementation1();
            Console.WriteLine();
            Implementation2();
            Console.WriteLine();
            Implementation3();
        }
        static void Implementation1()
        {
            int[] n = new int[10];
            for (int i = 0; i < n.Length; ++i)
                n[i] = 100 + i;
            for (int i = 0; i < n.Length; ++i)
                Console.WriteLine(n[i]);
        }
        static void Implementation2()
        {
            int[] n = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < n.Length; ++i)
                n[i] = 100 + i;
            foreach (var number in n)
                Console.WriteLine(number);
        }
        static void Implementation3()
        {
            var n = Enumerable.Range(100, 10).ToArray();
            string.Join(',', n.Select(val => $"{val}"));
            Console.WriteLine(string.Join(',', n.Select(val => $"{val}")));
        }
    }

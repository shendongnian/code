    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            foreach (var nbr in Fibo().Take(5000))
            {
                Console.Write(nbr.ToString() + " ");
            }
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine("Ellapsed : " + sw.Elapsed.ToString());
            Console.ReadLine();
        }
        static IEnumerable<long> Fibo()
        {
            long a = 0;
            long b = 1;
            long t;
            while (true)
            {
                t = a + b;
                yield return t;
                a = b;
                b = t;
            }
        }
    }

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
        static IEnumerable<int> Fibo()
        {
            int a = 0;
            int b = 1;
            while (true)
            {
                yield return a++ + b++;
            }
        }
    }

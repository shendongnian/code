    public class Program
    {
        public static void Main()
        {
            const int iterations = 1000 * 1000;
            const string input = "63559BC0-1FEF-4158-968E-AE4B94974F8E";
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                new Guid(input);
            }
            sw.Stop();
            Console.WriteLine("new Guid(): {0} ms", sw.ElapsedMilliseconds);
            sw = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
            {
                Guid.Parse(input);
            }
            sw.Stop();
            Console.WriteLine("Guid.Parse(): {0} ms", sw.ElapsedMilliseconds);
        }
    }

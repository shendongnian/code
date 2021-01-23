    public class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            const int iterations = 10000000;
    
            var hits1 = 1.0 * Enumerable.Range(1, iterations)
                                         .Select(i => random.Next(0, 4))
                                         .Where(i => i == 0).Count();
            Console.WriteLine(hits1 / iterations);
            var hits2 = 1.0 * Enumerable.Range(1, iterations)
                                         .Select(i => random.Next(0, 1000))
                                         .Where(i => i < 250)
                                         .Count();
            Console.WriteLine(hits2 / iterations);
        }
    }

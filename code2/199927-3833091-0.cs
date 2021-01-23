    class Program
    {
        static void Main(string[] args)
        {
            var ring = Enumerable.Range(97, 10).Select(x => (char)x).ToList();
            Console.WriteLine(string.Join("\n", Enumerable.Range(1, 10).Select(x => new string(ring.rotate(x).ToArray()))));
            Console.ReadLine();
        }
    }

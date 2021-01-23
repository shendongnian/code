    internal class Test
    {
        private static void Main(string[] args)
        {
            IThing thing = new Thing { Collection = new[] { 3, 4, 5 } };
            foreach (var i in thing.Collection)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }

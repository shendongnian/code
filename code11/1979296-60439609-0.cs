    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 2, 3, 1, 1, 5, 2, 6, 1 };
            var randomIndex = RandomIndexOf(arr, 1);
            Console.ReadKey();
        }
        static int RandomIndexOf<T>(ICollection<T> arr, T element)
        {
            var indexes = arr.Select((x, i) => new { Element = x, Index = i })
                .Where(x => element.Equals(x.Element))
                .Select(x => x.Index)
                .ToList();
            if (indexes.Count == 0) // there is no matching elements
            {
                return -1;
            }
            var rand = new Random();
            var randomIndex = rand.Next(0, indexes.Count);
            return indexes[randomIndex];
        }
    }

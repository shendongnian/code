    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<IEnumerable<int>> lists = new List<IEnumerable<int>> {
                                  new List<int> { 1, 2, 3, 4 },
                                  new List<int> { 2, 3, 4, 5, 8 },
                                  new List<int> { 2, 3, 4, 5, 9, 9 },
                                  new List<int> { 2, 3, 3, 4, 9, 10 }
                                };
            Console.WriteLine(string.Join(", ", GetNonShared(lists)
                .Distinct()
                .OrderBy(x => x)
                .Select(x => x.ToString())
                .ToArray()));
            Console.ReadKey();
        }
        public static HashSet<T> GetShared<T>(IEnumerable<IEnumerable<T>> lists)
        {
            HashSet<T> result = null;
            foreach (IEnumerable<T> list in lists)
            {
                if (result == null)
                {
                    result = new HashSet<T>(list);
                }
                else
                {
                    result.IntersectWith(list);
                }
            }
            return result;
        }
        public static IEnumerable<T> GetNonShared<T>(IEnumerable<IEnumerable<T>> lists)
        {
            HashSet<T> shared = GetShared(lists);
            return lists.SelectMany(x => x).Where(x => !shared.Contains(x));
        }
    }

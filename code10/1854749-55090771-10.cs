    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================== START ==========================");
            var onlyInList1 = CompareResults(List1, List2);
            var onlyInList2 = CompareResults(List2, List1);
            PrintResult(nameof(List1), onlyInList1);
            PrintResult(nameof(List2), onlyInList2);
            Console.WriteLine("====================== END ==========================");
            Console.ReadKey();
        }
        private static IEnumerable<Dictionary<string, object>> CompareResults(
            IEnumerable<Dictionary<string, object>> source,
            IEnumerable<Dictionary<string, object>> target)
        {
            for (var i = 0; i < source.Count(); i++)
            {
                // If there is no entry for the current index, complete dictionary from source will be returned.
                if (i >= target.Count())
                {
                    yield return source.ElementAt(i);
                    continue;
                }
                // Assuming you want to compare at the same index.
                yield return GetDiffs(
                    source.ElementAt(i),
                    target.ElementAt(i));
            }
        }
        public static Dictionary<string, object> GetDiffs(
            IDictionary<string, object> source,
            IDictionary<string, object> target)
        {
            return source
                .Where(x => !x.Value.Equals(target[x.Key]))
                .ToDictionary(
                    x => x.Key,
                    x => x.Value);
        }
        private static void PrintResult(string listName, IEnumerable<Dictionary<string, object>> list)
        {
            var it = 1;
            foreach (var dict in list)
            {
                Console.WriteLine($"**** {listName} - Dictionary {it} ****");
                foreach (var keyValuePair in dict)
                {
                    Console.WriteLine($"Result: {keyValuePair.Key} - {keyValuePair.Value}");
                }
                it++;
            }
        }
        private static IEnumerable<Dictionary<string, object>> List1 = new List<Dictionary<string, object>>()
        {
            new Dictionary<string, object>
            {
                {"key1", 1 },
                {"key2", DateTime.Now.Month },
                {"key3", "Same" },
                {"key4", true }
            },
            new Dictionary<string, object>
            {
                {"key1", 2 },
                {"key2", DateTime.Now.Year },
                {"key3", "2nd Dictionary" },
                {"key4", true }
            },
            new Dictionary<string, object>
            {
                {"key1", 2 },
                {"key2", DateTime.Now.AddDays(4) },
                {"key3", "2nd Dictionary" },
                {"key4", true }
            }
        };
        private static IEnumerable<Dictionary<string, object>> List2 = new List<Dictionary<string, object>>()
        {
            new Dictionary<string, object>
            {
                {"key1", 1 },
                {"key2", DateTime.Now.Month },
                {"key3", "Same" },
                {"key4", true }
            },
            new Dictionary<string, object>
            {
                {"key1", 4 },
                {"key2", "Key 2 string value" },
                {"key3", "2nd Dictionary" },
                {"key4", true }
            },
        };
    }

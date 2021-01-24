    class Program
    {
        static void Main(string[] args)
        {
            var it = 1;
            foreach (var dict in CompareResults(List1, List2))
            {
                Console.WriteLine($"**** List 1 - Dictionary {it} ****");
                foreach (var keyValuePair in dict)
                {
                    Console.WriteLine($"I'm present only in first one: {keyValuePair.Key} - {keyValuePair.Value}");
                }
                it++;
            }
            Console.WriteLine("=======================================================");
            it = 1;
            foreach (var dict in CompareResults(List2, List1))
            {
                Console.WriteLine($"**** List 2 - Dictionary {it} ****");
                foreach (var keyValuePair in dict)
                {
                    Console.WriteLine($"I'm present only in second one: {keyValuePair.Key} - {keyValuePair.Value}");
                }
                it++;
            }
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

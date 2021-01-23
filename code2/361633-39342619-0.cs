    static void Main(string[] args)
        {
            List<List<long>> result = new List<List<long>>();
            List<long> set = new List<long>() { 1, 2, 3, 4 };
            GetCombination<long>(set, result);
            result.Add(set);
            IOrderedEnumerable<List<long>> sorted = result.OrderByDescending(s => s.Count);
            sorted.ToList().ForEach(l => { l.ForEach(l1 => Console.Write(l1 + " ")); Console.WriteLine(); });
        }
        private static void GetCombination<T>(List<T> set, List<List<T>> result)
        {
            for (int i = 0; i < set.Count; i++)
            {
                List<T> temp = new List<T>(set.Where((s, index) => index != i));
                if (temp.Count > 0 && !result.Where(l => l.Count == temp.Count).Any(l => l.SequenceEqual(temp)))
                {
                    result.Add(temp);
                    GetCombination<T>(temp, result);
                }
            }
        }

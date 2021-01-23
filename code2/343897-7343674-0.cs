    public static class ListExtensions
    {
        public static void StableSort<T>(this List<T> list, IComparer<T> comparer)
        {
            var pairs = list.Select((value, index) => Tuple.Create(value, index)).ToList();
            pairs.Sort((x, y) =>
                {
                    int result = comparer.Compare(x.Item1, y.Item1);
                    return result != 0 ? result : x.Item2 - y.Item2;
                });
            list.Clear();
            list.AddRange(pairs.Select(key => key.Item1));
        }
    }

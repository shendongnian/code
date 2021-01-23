    public static class CollatzConjexture2
    {
        public static int Calculate(int StartIndex, int MaxSequence)
        {
            var nums = Enumerable.Range(StartIndex, MaxSequence);
            return nums.AsParallel()
                       .Select(n => new { key = n, len = CollatzChainLength(n) })
                       .MaxBy(x => x.len)
                       .key;
        }
        private static int CollatzChainLength(Int64 Number)
        {
            int chainLength;
            for (chainLength = 1; Number != 1; chainLength++)
                Number = CalculateCollatzConjecture(Number);
            return chainLength;
        }
        private static Int64 CalculateCollatzConjecture(Int64 Number)
        {
            if (Number % 2 == 0)
                return Number / 2;
            else
                return (3 * Number) + 1;
        }
        public static TSource MaxBy<TSource, TResult>(
            this IEnumerable<TSource> collection, Func<TSource, TResult> func)
        {
            var comparer = Comparer<TResult>.Default;
            TSource maxItem = default(TSource);
            TResult maxVal = default(TResult);
            bool first = true;
            foreach (var item in collection)
                if (first)
                {
                    first = false;
                    maxItem = item;
                    maxVal = func(item);
                }
                else if (comparer.Compare(func(item), func(maxItem)) > 0)
                {
                    maxItem = item;
                    maxVal = func(item);
                }
            return maxItem;
        }
    }

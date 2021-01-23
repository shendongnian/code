    public static class CollatzConjexture2
    {
        public static int Calculate(int StartIndex, int MaxSequence)
        {
            var nums = Enumerable.Range(StartIndex, MaxSequence);
            return nums.AsParallel()
                        // compute length of chain for each number
                       .Select(n => new { key = n, len = CollatzChainLength(n) })
                        // find longest chain
                       .Aggregate((max, cur) => max.len < cur.len ? cur : max)
                        // get number that produced longest chain
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
    }

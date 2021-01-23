    public static class CollatzConjexture2
    {
        public static int Calculate(int StartIndex, int MaxSequence)
        {
            var nums = Enumerable.Range(StartIndex, MaxSequence);
            return nums.AsParallel()
                        // compute length of chain for each number
                       .Select(n => new { key = n, len = CollatzChainLength(n) })
                        // find longest chain
                       .Aggregate((max, cur) => cur.len > max.len ||
                        // make sure we have lowest key for longest chain
                          max.len == cur.len && cur.key < max.key ? cur : max)
                        // get number that produced longest chain
                       .key;
        }
        private static int CollatzChainLength(Int64 Number)
        {
            int chainLength;
            for (chainLength = 1; Number != 1; chainLength++)
                Number = (Number & 1) == 0 ? Number >> 1 : Number * 3 + 1;
            return chainLength;
        }
    }

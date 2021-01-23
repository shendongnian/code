    class GetSetsWithAdjacent
    {
        public struct CountEm
        {
            public int start;
            public int count;
            override public string ToString()
            {
                return string.Format("start={0}, count={1}", this.start, this.count);
            }
        }
        static public IEnumerable<CountEm> GenCount(int[] inputs)
        {
            return GenCount(((IEnumerable<int>)inputs).GetEnumerator());
        }
        static public IEnumerable<CountEm> GenCount(IEnumerator<int> inputs)
        {
            if (inputs.MoveNext())
            {
                CountEm result = new CountEm {start = inputs.Current, count = 1 };
                while (inputs.MoveNext())
                {
                    if (result.start + result.count == inputs.Current)
                    {
                        result.count += 1;
                    }
                    else
                    {
                        yield return result;
                        result = new CountEm { start = inputs.Current, count = 1 };
                    }
                }
                yield return result;
            }
        }
    }
    class StackOverflow
    {
        private static void Test_GetSetsWithAdjacent()
        {
            // http://stackoverflow.com/questions/7064157/c-linq-get-sets-with-adjacent
            int[] inputs = { 0, 1, 2, 6, 7, 10 };
            foreach (GetSetsWithAdjacent.CountEm countIt in GetSetsWithAdjacent.GenCount(inputs))
            {
                Console.WriteLine(countIt);
            }
        }
        internal static void Test()
        {
            Test_GetSetsWithAdjacent();
        }
    }

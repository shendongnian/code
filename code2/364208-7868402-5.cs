    class Program
    {
        class ArraySegmentComparer : IEqualityComparer<ArraySegment<char>>
        {
            public bool Equals(ArraySegment<char> x, ArraySegment<char> y)
            {
                if (x.Count != y.Count)
                {
                    return false;
                }
                int end = x.Offset + x.Count;
                for (int i = x.Offset, j = y.Offset; i < end; i++, j++)
                {
                    if (!x.Array[i].ToString().Equals(y.Array[j].ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        return false;
                    }
                }
                return true;
            }
                unchecked
                {
                    int hash = 17;
                    int end = obj.Offset + obj.Count;
                    int i;
                    for (i = obj.Offset; i < end; i++)
                    {
                        hash *= 23;
                        hash += Char.ToUpperInvariant(obj.Array[i]);
                    }
                    return hash;
                }
            }
        }
        static void Main()
        {
            var rx = new Regex(@"\b\w+\b", RegexOptions.Compiled);
            var sampleText = @"For my custom made chat screen i am using the code below for checking censored words. But i wonder can this code performance improved. Thank you.

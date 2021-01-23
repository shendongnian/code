    public static int IndexOfSequence<T>(this IEnumerable<T> longL, IEnumerable<T> subL)
        {
            var longList = longL.ToList();
            var subList = subL.ToList();
            int longCount = longList.Count;
            int subCount = subList.Count;
            if (subCount > longCount)
            {
                return -1;
            }
            int numTries = longCount - subCount + 1;
            for (int i = 0; i < numTries; i++)
            {
                var newList = new List<T>(longList.Skip(i).Take(subCount));
                if (newList.SequenceEqual(subList))
                {
                    return i;
                }
            }
            return -1;
        }

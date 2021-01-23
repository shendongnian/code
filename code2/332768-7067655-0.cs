    public static int ContainsSequence<T>(this IEnumerable<T> longList, IEnumerable<T> subList)
        {
            int longCount = longList.Count();
            int subCount = subList.Count();
            if (subCount > longCount)
            {
                return false;
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

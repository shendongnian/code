    public static void RemoveDuplicates<T>(this IList<T> list, IEqualityComparer<T> comparer = null)
    {
        comparer = comparer ?? EqualityComparer<T>.Default;
    
        var uniques = new HashSet<T>(comparer);
        for (int i = list.Count - 1; i >= 0; --i)
        {
            if (!uniques.Add(list[i]))
            {
                list.RemoveAt(i);
            }
        }
    }

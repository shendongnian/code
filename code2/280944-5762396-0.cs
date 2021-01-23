    public static int CountDifferences<T>(this IList<T> list1, IList<T> list2)
    {
        if(list1.Count != list2.Count)
            throw new ArgumentException("Lists must have same # elements", "list2");
        return list1.Where((t, i) => !Equals(t, list2[i])).Count();
    }

    public static int CountDifferences<T> (this IList<T> list1, IList<T> list2)
    {
        if (list1.Count != list2.Count)
            throw new ArgumentException ("Lists must have the same number of elements", "list2");
    
        return list1.Count - list1.Intersect(list2).Count();
    } 

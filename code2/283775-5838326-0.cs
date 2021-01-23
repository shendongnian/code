    public static IsEmpty(this IEnumerable list)
    {
        IEnumerator en = list.GetEnumerator();
        return !en.MoveNext();
    }

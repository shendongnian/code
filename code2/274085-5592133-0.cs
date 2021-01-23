    public static List<List<T>> Split(List<T> source, int size)
    {
        // TODO: Prepopulate with the right capacity
        List<List<T>> ret = new List<List<T>>();
        for (int i = 0; i < source.Count; i += size)
        {
            ret.Add(source.GetRange(i, Math.Min(size, source.Count - i)));
        }
        return ret;
    }

    public static List<T> GetRange(T start, T end, Func<T,T> increment)
    {
        List<T> result = new List<T>();
        for(T t = start; t.CompareTo(end) < 0; t = increment(t))
        {
            result.Add(t);
        }
        return result;
    }
    List<DateTime> values = GetRange<DateTime>(myRange.Start, myRange.End, d => d.AddDays(1));

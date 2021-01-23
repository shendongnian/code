    bool hasSameElements = A.HasSameElements(B);
    // ...
    public static bool HasSameElements<T>(this IEnumerable<T> a, IEnumerable<T> b)
    {
        if (a == b) return true;
        if ((a == null) || (b == null)) return false;
        if (a.Count != b.Count) return false;
        var dict = new Dictionary<string, int>(a.Count);
        foreach (string s in a)
        {
            int count;
            dict.TryGetValue(s, out count);
            dict[s] = count + 1;
        }
        foreach (string s in b)
        {
            int count;
            if (!dict.TryGetValue(s, out count)) return false;
            if (count < 1) return false;
            dict[s] = count - 1;
        }
        return dict.All(kvp => kvp.Value == 0);
    }

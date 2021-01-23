    public static bool ContainsSubsequence<T>(this IEnumerable<T> parent, IEnumerable<T> target)
    {
        var pattern = target.ToArray();
        var source = new LinkedList<T>();
        foreach (var element in parent) 
        {
            source.AddLast(element);
            if(source.Count == pattern.Length)
            {
                if(source.SequenceEqual(pattern))
                    return true;
                source.RemoveFirst();
            }
        }
        return false;
    }

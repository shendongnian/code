    public static IEnumerable<T[]> Chunks<T>(this IEnumerable<T> xs, int size, bool returnRest = false)
    {
        var curr = new T[size];
    
        int i = 0;
    
        foreach (var x in xs)
        {
            if (i == size)
            {
                yield return curr;
                i = 0;
                curr = new T[size];
            }
    
            curr[i++] = x;
        }
    
        if (returnRest)
            yield return curr.Take(i).ToArray();
    }

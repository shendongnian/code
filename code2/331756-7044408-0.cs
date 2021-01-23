    public static T[] JoinArrays<T>(this IEnumerable<T[]> self)
    {
        if (self == null)
            throw new ArgumentNullException("self");
 
        int count = 0;
 
        foreach (var arr in self)
            if (arr != null)
                count += arr.Length;
 
        var joined = new T[count];
 
        int index = 0;
 
        foreach (var arr in self)
            if (arr != null)
            {
                Array.Copy(arr, 0, joined, index, arr.Length);
                index += arr.Length;
            }
 
        return joined;
    }

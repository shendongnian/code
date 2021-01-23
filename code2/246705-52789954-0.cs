    public static T Max<T>(IEnumerable<T> source) where T:IComparable<T>
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));
    
        T max = source.FirstOrDefault();
    
        foreach (var item in source)
        {
            if (item.CompareTo(max) == 1)
                max = item;
        }
    
        return max;
    }

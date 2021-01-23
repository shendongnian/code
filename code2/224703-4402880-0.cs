    public static T[] Insert<T>(this T[] source, int index, T item)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
    
        if (index < 0 || index > source.Length)
        {
            throw new ArgumentOutOfRangeException("index");
        }
    
        T[] result = new T[source.Length + 1];
    
        for (int i = 0; i < index; ++i)
        {
            result[i] = source[i];
        }
    
        result[index] = item;
    
        for (int i = index; i < source.Length; ++i)
        {
            result[i + 1] = source[i];
        }
    
        return result;
    }

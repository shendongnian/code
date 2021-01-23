    public static TTarget[] Convert<TSource, TTarget>(TSource[] data,
        Func<TSource, TTarget> conversion)
    {
        TargetType[] result = new TargetType[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            result[i] = conversion(data[i]);
        }
        return result;
    }
    

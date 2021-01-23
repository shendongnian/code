    public delegate bool TryParser<T>(string text, out T result) where T : struct;
    
    public static T? TryParse<T>(string text, TryParser<T> tryParser)
                                 where T : struct
    {
        // null checks here.
        T result;
        return tryParser(text, out result) ? result : new T?();
    }

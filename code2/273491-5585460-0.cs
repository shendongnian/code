    public static IEnumerable<T> Blowout<T>(T value, int length)
    {
        for (int i = 0; i < length; i++) yield return value;
    }
    
    dictionary
        .SelectMany(pair => Blowout((double)pair.Key, pair.Value));

    static IEnumerable<T> GetFlags<T>(Enum input)
    {
        foreach (object value in Enum.GetValues(typeof(T)))
        {
            if (input.HasFlag((Enum)value))
                yield return (T)value;
        }
    }

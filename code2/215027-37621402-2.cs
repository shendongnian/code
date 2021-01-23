    /// <summary>
    /// Return an enumerators of input flag(s)
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static IEnumerable<T> GetFlags<T>(this T input)
    {
        foreach (Enum value in Enum.GetValues(input.GetType()))
        {
            if ((int) (object) value != 0) // Just in case somebody has defined an enum with 0.
            {
                if (((Enum) (object) input).HasFlag(value))
                    yield return (T) (object) value;
            }
        }
    }

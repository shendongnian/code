    public static string FlagsEnumToString<T>(object e)
    {
        var str = new StringBuilder();
        foreach (object i in Enum.GetValues(typeof(T)))
        {
            if (IsExactlyOneBitSet((int) i) &&
                ((Enum) e).HasFlag((Enum) i))
            {
                str.Append((T) i + ", ");
            }
        }
        if (str.Length > 0) str.Length -= 2;
        return str.ToString();
    }
    static bool IsExactlyOneBitSet(int i)
    {
        return i != 0 && (i & (i - 1)) == 0;
    }

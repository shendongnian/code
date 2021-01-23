    const string Separator = ", ";
    public static string FlagsEnumToString<T>(Enum e)
    {
        var str = new StringBuilder();
        foreach (object i in Enum.GetValues(typeof(T)))
        {
            if (IsExactlyOneBitSet((int) i) &&
                e.HasFlag((Enum) i))
            {
                str.Append((T) i + Separator);
            }
        }
        if (str.Length > 0)
        {
            str.Length -= Separator.Length;
        }
        return str.ToString();
    }
    static bool IsExactlyOneBitSet(int i)
    {
        return i != 0 && (i & (i - 1)) == 0;
    }

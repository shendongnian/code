    public static bool InclusiveBetween (this IComparable a, IComparable b, IComparable c)
    {
        return a.CompareTo(b) >= 0 && a.CompareTo(c) <= 0;
    }
    public static bool ExclusiveBetween (this IComparable a, IComparable b, IComparable c)
    {
        return a.CompareTo(b) > 0 && a.CompareTo(c) < 0;
    }
    public static bool SqlBetween (this IComparable a, IComparable b, IComparable c)
    {
        return a.InclusiveBetween(b, c);
    }

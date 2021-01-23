    public static T Min<T>(params T[] values) where T : IComparable<T>
    {
        T min = values[0];
        foreach (var item in values.Skip(1))
        {
            if (item.CompareTo(min) < 0)
                min = item;
        }
        return min;
    }

    private static ulong GetEnumContiguousCount(Type enumType)
    {
        var underlyingType = Enum.GetUnderlyingType(enumType);
        ulong i;
        for (i = 0; Enum.IsDefined(enumType, Convert.ChangeType(i, underlyingType, null)); ++i) {}
        return i;
    }

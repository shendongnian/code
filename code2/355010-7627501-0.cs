    private ulong GetEnumContiguousCount(Type enumType)
    {
        var underlyingType = Enum.GetUnderlyingType(enumType);
        for (ulong i = 0; Enum.IsDefined(enumType, Convert.ChangeType(i, underlyingType, null)); ++i) {}
        return i;
    }

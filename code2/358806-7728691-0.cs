    static void foo(Type typeEnum)
    {
        var underlyingType = Enum.GetUnderlyingType(typeEnum);
        if (typeEnum.IsEnum)
        {
            foreach (var enumVal in Enum.GetValues(typeEnum))
            {
                var _val = Convert.ChangeType(enumVal, underlyingType);
            }
        }
    }

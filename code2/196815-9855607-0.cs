    public static bool IsCharEnum(this Type T)
    {
        var enumType = T.IsNullableEnum() ? Nullable.GetUnderlyingType(T) : T;
        if (!enumType.IsEnum) return false;
        try
        {
            return ((int[])Enum.GetValues(enumType)).All(i => char.IsLetter((char)i));
        }
        catch
        {
            return false;
        }
    }
    
    public static bool IsNullableEnum(this Type T)
    {
        var u = Nullable.GetUnderlyingType(T);
        return (u != null) && u.IsEnum;
    }

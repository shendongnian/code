    public static bool IsIntegral(this Type type)
    {
        var typeCode = (int) Type.GetTypeCode(type);
        return typeCode > 4 && typeCode < 13;
    }

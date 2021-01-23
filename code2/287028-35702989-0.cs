    /// <summary>
    /// Table that maps TypeCode to it's corresponding Type.
    /// </summary>
    static IReadOnlyDictionary<TypeCode, Type> TypeCodeToTypeMap = new Dictionary<TypeCode, Type>
    {
        { TypeCode.Boolean, typeof(bool) },
        { TypeCode.Byte, typeof(byte) },
        { TypeCode.Char, typeof(char) },
        { TypeCode.DateTime, typeof(DateTime) },
        { TypeCode.DBNull, typeof(DBNull) },
        { TypeCode.Decimal, typeof(decimal) },
        { TypeCode.Double, typeof(double) },
        { TypeCode.Empty, null },
        { TypeCode.Int16, typeof(short) },
        { TypeCode.Int32, typeof(int) },
        { TypeCode.Int64, typeof(long) },
        { TypeCode.Object, typeof(object) },
        { TypeCode.SByte, typeof(sbyte) },
        { TypeCode.Single, typeof(Single) },
        { TypeCode.String, typeof(string) },
        { TypeCode.UInt16, typeof(UInt16) },
        { TypeCode.UInt32, typeof(UInt32) },
        { TypeCode.UInt64, typeof(UInt64) }
    };
    /// <summary>
    /// Convert a TypeCode ordinal into it's corresponding Type instance.
    /// </summary>
    public static Type ToType(this TypeCode code)
    {
        Type type = null;
        TypeCodeToTypeMap.TryGetValue(code, out type);
        
        return type;
    }

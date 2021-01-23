    private static Dictionary<Type, string> shorthandMap = new Dictionary<Type, string>
    {
        { typeof(Boolean), "bool" },
        { typeof(Byte), "byte" },
        { typeof(Char), "char" },
        { typeof(Decimal), "decimal" },
        { typeof(Double), "double" },
        { typeof(Single), "float" },
        { typeof(Int32), "int" },
        { typeof(Int64), "long" },
        { typeof(SByte), "sbyte" },
        { typeof(Int16), "short" },
        { typeof(String), "string" },
        { typeof(UInt32), "uint" },
        { typeof(UInt64), "ulong" },
        { typeof(UInt16), "ushort" },
    };
    private static string CSharpTypeName(Type type, bool isOut = false)
    {
        if (type.IsByRef)
        {
            return String.Format("{0} {1}", isOut ? "out" : "ref", CSharpTypeName(type.GetElementType()));
        }
        if (type.IsGenericType)
        {
            if (type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return String.Format("{0}?", CSharpTypeName(Nullable.GetUnderlyingType(type)));
            }
            else
            {
                return String.Format("{0}<{1}>", type.Name.Split('`')[0],
                    String.Join(", ", type.GenericTypeArguments.Select(a => CSharpTypeName(a)).ToArray()));
            }
        }
        if (type.IsArray)
        {
            return String.Format("{0}[]", CSharpTypeName(type.GetElementType()));
        }
        return shorthandMap.ContainsKey(type) ? shorthandMap[type] : type.Name;
    }

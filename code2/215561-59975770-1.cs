    public static class TypeNameExtensions
    {
        public static string GetFriendlyName(this Type type, bool aliasNullable = true, bool includeSpaceAfterComma = true)
        {
            TryGetInnerElementType(ref type, out string arrayBrackets);
            if (!TryGetNameAliasNonArray(type, out string friendlyName))
            {
                if (!type.IsGenericType)
                {
                    friendlyName = type.Name;
                }
                else
                {
                    if (aliasNullable && type.GetGenericTypeDefinition() == typeof(System.Nullable<>))
                    {
                        string generics = GetFriendlyName(type.GetGenericArguments()[0]);
                        friendlyName = generics + "?";
                    }
                    else
                    {
                        string generics = GetFriendlyGenericArguments(type, includeSpaceAfterComma);
                        int iBacktick = type.Name.IndexOf('`');
                        friendlyName = (iBacktick > 0 ? type.Name.Remove(iBacktick) : type.Name)
                            + $"<{generics}>";
                    }
                }
            }
            return friendlyName + arrayBrackets;
        }
        public static bool TryGetNameAlias(this Type type, out string alias)
        {
            TryGetInnerElementType(ref type, out string arrayBrackets);
            if (!TryGetNameAliasNonArray(type, out alias))
                return false;
            alias += arrayBrackets;
            return true;
        }
        private static string GetFriendlyGenericArguments(Type type, bool includeSpaceAfterComma)
            => string.Join(
                includeSpaceAfterComma ? ", " : ",",
                type.GetGenericArguments().Select(t => t.GetFriendlyName())
                );
        private static bool TryGetNameAliasNonArray(Type type, out string alias)
            => (alias = TypeAliases[(int)Type.GetTypeCode(type)]) != null
            && !type.IsEnum;
        private static bool TryGetInnerElementType(ref Type type, out string arrayBrackets)
        {
            arrayBrackets = null;
            if (!type.IsArray)
                return false;
            do
            {
                arrayBrackets += "[" + new string(',', type.GetArrayRank() - 1) + "]";
                type = type.GetElementType();
            }
            while (type.IsArray);
            return true;
        }
        private static readonly string[] TypeAliases = {
            "void",     // 0
            null,       // 1 (any other type)
            "DBNull",   // 2
            "bool",     // 3
            "char",     // 4
            "sbyte",    // 5
            "byte",     // 6
            "short",    // 7
            "ushort",   // 8
            "int",      // 9
            "uint",     // 10
            "long",     // 11
            "ulong",    // 12
            "float",    // 13
            "double",   // 14
            "decimal",  // 15
            null,       // 16 (DateTime)
            null,       // 17 (-undefined-)
            "string",   // 18
        };
    }

    public static class CSharpAmbiance
    {
        private static Dictionary<Type, string> aliases =
            new Dictionary<Type, string>();
        static CSharpAmbiance()
        {
            aliases[typeof(byte)] = "byte";
            aliases[typeof(sbyte)] = "sbyte";
            aliases[typeof(short)] = "short";
            aliases[typeof(ushort)] = "ushort";
            aliases[typeof(int)] = "int";
            aliases[typeof(uint)] = "uint";
            aliases[typeof(long)] = "long";
            aliases[typeof(ulong)] = "ulong";
            aliases[typeof(char)] = "char";
            aliases[typeof(float)] = "float";
            aliases[typeof(double)] = "double";
            aliases[typeof(decimal)] = "decimal";
            aliases[typeof(bool)] = "bool";
            aliases[typeof(object)] = "object";
            aliases[typeof(string)] = "string";
        }
        private static string RemoveGenericNamePart(string name)
        {
            int backtick = name.IndexOf('`');
            if (backtick != -1)
                name = name.Substring(0, backtick);
            return name;
        }
        public static string GetTypeName(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            string keyword;
            if (aliases.TryGetValue(type, out keyword))
                return keyword;
            if (type.IsArray) {
                var sb = new StringBuilder();
                sb.Append(GetTypeName(type.GetElementType()));
                sb.Append('[');
                int rank = type.GetArrayRank() - 1;
                for (int i = 0; i < rank; i++)
                    sb.Append(',');
                sb.Append(']');
                return sb.ToString();
            }
            if (type.IsGenericTypeDefinition) {
                var sb = new StringBuilder();
                sb.Append(RemoveGenericNamePart(type.FullName));
                sb.Append('<');
                var args = type.GetGenericArguments().Length - 1;
                for (int i = 0; i < args; i++)
                    sb.Append(',');
                sb.Append('>');
                return sb.ToString();
            }
            if (type.IsGenericType) {
                if (type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    return GetTypeName(type.GetGenericArguments()[0]) + "?";
                var sb = new StringBuilder();
                sb.Append(RemoveGenericNamePart(type.FullName));
                sb.Append('<');
                var args = type.GetGenericArguments();
                for (int i = 0; i < args.Length; i++) {
                    if (i != 0)
                        sb.Append(", ");
                    sb.Append(GetTypeName(args[i]));
                }
                sb.Append('>');
                return sb.ToString();
            }
            return type.FullName;
        }
    }

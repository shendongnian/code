    public static class TypeFriendlyNamesExtensions
    {
        private static readonly Dictionary<Type, string> TypeToFriendlyName = new Dictionary<Type, string>
        {
            {typeof(string), "string"},
            {typeof(object), "object"},
            {typeof(bool), "bool"},
            {typeof(byte), "byte"},
            {typeof(char), "char"},
            {typeof(decimal), "decimal"},
            {typeof(double), "double"},
            {typeof(short), "short"},
            {typeof(int), "int"},
            {typeof(long), "long"},
            {typeof(sbyte), "sbyte"},
            {typeof(float), "float"},
            {typeof(ushort), "ushort"},
            {typeof(uint), "uint"},
            {typeof(ulong), "ulong"},
            {typeof(void), "void"}
        };
        public static string ToCSharpMethodReturnTypeName(this Type type)
        {
            var sb = new StringWriter();
            ToCSharpNameEntry2(sb, type);
            return sb.ToString();
        }
        private static void ToCSharpNameEntry2(TextWriter sb, Type type0)
        {
            var list = GetContainingTypeList(type0);
            var usedGenericArgumentCounter = 0;
            HandleNestedLevel(sb, list, 0, ref usedGenericArgumentCounter);
            foreach (var ix in Enumerable.Range(1, list.Count - 1))
            {
                sb.Write(".");
                HandleNestedLevel(sb, list, ix, ref usedGenericArgumentCounter);
            }
        }
        private static void HandleNestedLevel(TextWriter sb, IReadOnlyList<Type> list, int ix,
            ref int usedGenericArgumentCounter)
        {
            var type = list[ix];
            if (TypeToFriendlyName.TryGetValue(type, out string fname))
            {
                sb.Write(fname);
                return;
            }
            if (type.IsGenericParameter)
            {
                sb.Write(type.Name);
                return;
            }
            if (type.IsArray)
            {
                ToCSharpNameEntry2(sb, type.GetElementType());
                sb.Write("[]");
                return;
            }
            if (type.IsGenericType)
            {
                var innermostType = list[list.Count - 1];
                var args = list[list.Count - 1].GenericTypeArguments;
                if (!type.IsConstructedGenericType)
                {
                    if (innermostType.IsConstructedGenericType)
                    {
                        var sname = GetSname(type);
                        sb.Write(sname);
                        sb.Write("<");
                        ToCSharpNameEntry2(sb, args[usedGenericArgumentCounter++]);
                        var loopCounter = ((TypeInfo) type).GenericTypeParameters.Length;
                        while (0 < --loopCounter)
                        {
                            sb.Write(",");
                            ToCSharpNameEntry2(sb, args[usedGenericArgumentCounter++]);
                        }
                        sb.Write(">");
                        return;
                    }
                    throw new NotImplementedException();
                }
                if (typeof(Nullable<>) == type.GetGenericTypeDefinition())
                {
                    ToCSharpNameEntry2(sb, args[0]);
                    sb.Write("?");
                    return;
                }
                var cname = GetSname(type);
                sb.Write(cname);
                sb.Write("<");
                ToCSharpNameEntry2(sb, args[usedGenericArgumentCounter++]);
                while (usedGenericArgumentCounter < args.Length)
                {
                    sb.Write(",");
                    ToCSharpNameEntry2(sb, args[usedGenericArgumentCounter++]);
                }
                sb.Write(">");
                return;
            }
            if (type.IsPointer)
            {
                ToCSharpNameEntry2(sb, type);
                sb.Write("*");
                return;
            }
            sb.Write(type.Name);
        }
        private static string GetSname(Type type)
        {
            var name = type.Name;
            return name.Substring(0, name.IndexOf('`'));
        }
        private static List<Type> GetContainingTypeList(Type type)
        {
            var list = new List<Type> {type};
            var t = type;
            while (t.IsNested)
            {
                t = t.DeclaringType;
                list.Insert(0, t);
            }
            return list;
        }
        private static void ToCSharpNameEntry(StringBuilder sb, Type type)
        {
            var genericTypeArguments = type.GenericTypeArguments;
            var usedGenericTypeCounter = 0;
            ToCSharpNameRecursive(sb, type, genericTypeArguments, ref usedGenericTypeCounter);
        }
        private static void ToCSharpNameRecursive(StringBuilder sb, Type type, IReadOnlyList<Type> genericTypeArguments,
            ref int genericTypesCounter)
        {
            if (TypeToFriendlyName.TryGetValue(type, out string res))
            {
                sb.Append(res);
                return;
            }
            HandleNonPriminiveTypes(sb, type, genericTypeArguments, ref genericTypesCounter);
        }
        private static void HandleNonPriminiveTypes(StringBuilder sb, Type type, IReadOnlyList<Type> typeGenericTypeArguments,
            ref int genericTypesCounter)
        {
            var list = new List<Type>();
            var t = type;
            list.Add(t);
            while (t.IsNested)
            {
                t = t.DeclaringType;
                list.Add(t);
            }
            list.Reverse();
            foreach (var type1 in list)
            {
                HandleNestedLevel(sb, type1, typeGenericTypeArguments, ref genericTypesCounter);
                sb.Append(".");
            }
            sb.Length -= 1;
        }
        private static void HandleNestedLevel(StringBuilder sb, Type type, IReadOnlyList<Type> typeGenericTypeArguments,
            ref int genericTypesCounter)
        {
            var name = type.Name;
            if (type.IsGenericType)
            {
                var info = type.GetTypeInfo();
                var def = info.GetGenericTypeDefinition();
                var psLength = info.IsConstructedGenericType
                    ? info.GenericTypeArguments.Length
                    : info.GenericTypeParameters.Length;
                if (typeof(Nullable<>) == def)
                {
                    var type1 = typeGenericTypeArguments[genericTypesCounter++];
                    ToCSharpNameEntry(sb, type1);
                    sb.Append("?");
                    return;
                }
                var n = name.Substring(0, name.IndexOf("`", StringComparison.InvariantCultureIgnoreCase));
                sb.Append(n);
                sb.Append("<");
                for (var i = 0; i < psLength; i++)
                {
                    ToCSharpNameEntry(sb, typeGenericTypeArguments[genericTypesCounter++]);
                    sb.Append(",");
                }
                sb.Length -= 1;
                sb.Append(">");
                return;
            }
            if (type.IsArray)
            {
                var type1 = type.GetElementType();
                ToCSharpNameEntry(sb, type1);
                sb.Append("[]");
                return;
            }
            sb.Append(name);
        }
    }

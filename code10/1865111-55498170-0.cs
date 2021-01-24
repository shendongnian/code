    static Type GetType(Assembly assembly, string typeName)
    {
        Type type = assembly.GetType(typeName);
        if (type == null)
        {
            int index = typeName.IndexOf("`1");
            if (index != -1)
            {
                index += 2;
                ReadOnlySpan<char> span = typeName.AsSpan();
                type = Type.GetType(span.Slice(0, index).ToString());
                return type.MakeGenericType(Type.GetType(span.Slice(index + 1, span.Length - index - 2).ToString()));
            }
        }
        return type;
    }

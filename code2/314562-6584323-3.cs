    public static string GetFriendlyTypeName(Type type) {
        if (type.IsGenericParameter)
        {
            return type.Name;
        }
    
        if (!type.IsGenericType)
        {
            return type.FullName;
        }
    
        var builder = new System.Text.StringBuilder();
        var name = type.Name;
        var index = name.IndexOf("`");
        builder.AppendFormat("{0}.{1}", type.Namespace, name.Substring(0, index));
        builder.Append('<');
        var first = true;
        foreach (var arg in type.GetGenericArguments())
        {
            if (!first)
            {
                builder.Append(',');
            }
            builder.Append(GetFriendlyTypeName(arg));
            first = false;
        }
        builder.Append('>');
        return builder.ToString();
    }

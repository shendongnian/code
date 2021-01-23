    public static string ToCreationMethod(this object o)
    {
        return String.Format("var newObject = {0};", o.CreateObject());
    }
    private static StringBuilder CreateObject(this object o)
    {
        var builder = new StringBuilder();
        builder.AppendFormat("new {0} {{ ", o.GetClassName());
        foreach (var property in o.GetType().GetProperties())
        {
            var value = property.GetValue(o);
            if (value != null)
            {
                builder.AppendFormat("{0} = {1}, ", property.Name, value.GetCSharpString());
            }
        }
        builder.Append("}");
        return builder;
    }
    private static string GetClassName(this object o)
    {
        var type = o.GetType();
        if (type.IsGenericType)
        {
            var arg = type.GetGenericArguments().First().Name;
            return type.Name.Replace("`1", string.Format("<{0}>", arg));
        }
        return type.Name;
    }

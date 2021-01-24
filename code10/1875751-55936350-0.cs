    public static void AppendIfNotNull<TValue>(this StringBuilder sb, TValue value, string prefix, string suffix)
        where TValue : class 
    {
        if (value != null)
        {
            sb.Append(prefix + value + suffix);
        }
    }
    sb.AppendIfNotNull(item.width, " width=\"", "\"");

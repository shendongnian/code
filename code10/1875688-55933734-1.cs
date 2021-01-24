    public static class StringBuilderExtension
    {
        public static void AppendIfNotNull<TValue>(this StringBuilder sb, TValue value, string prefix)
            where TValue : class 
        {
            if (value != null)
            {
                sb.Append(prefix + value);
            }
        }
    }

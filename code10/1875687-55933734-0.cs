    public static class StringBuilderExtension
    {
        public static void AppendIfNotNull<TValue>(this StringBuilder sb, TValue value)
            where TValue : class 
        {
            if (value != null)
            {
                sb.Append("background-color=" + value);
            }
        }
    }

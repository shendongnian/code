    public static class Extension
    {
        public static string ToStringOrEmpty(this string value)
        {
            return value == null ? "" : value.ToString();
        }
    }

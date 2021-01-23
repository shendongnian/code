    public static class MyStringExtensions
    {
        public static string ToClassAttribute(this string s)
        {
            return String.IsNullOrWhiteSpace(s) ? String.Empty : "class=\"" + s + "\"";
        }
    }

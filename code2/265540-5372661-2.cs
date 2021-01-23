    public static class MyStringExtensions
    {
        public static string ToAttribute(this string s, string attribute)
        {
            return String.IsNullOrWhiteSpace(s) ? String.Empty : attribute + "=\"" + s + "\"";
        }
    }

    namespace ExtensionMethods
    {
        public static class StringExtensionMethods
        {
            public static string EnsureEndsWithDot(this string str)
            {
                if (!str.EndsWith(".")) return str + ".";
                return str;
            }
        }
    }

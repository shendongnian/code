    public static class StringExtensions
    {
        public static string Right(this string str, int length)
        {
            return str.Substring(str.Length - length, length);
        }
        public static string MyLast(this string str, int length)
        {
            if (str == null)
                return null;
            else if (str.Length >= length)
                return str.Substring(str.Length - length, length);
            else
                return str;
        }
    }

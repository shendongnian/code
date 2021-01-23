    public static class StringExtensions
    {
        public static string Truncate(this String str, int length)
        {
            return str.Substring(0, length) + "...";
        }
    }   

    static class MyExtensions
    {
        public static int? ParseInt(this string s)
        {
            int value;
            return Int32.TryParse(s, out value) ? value : (int?)null;
        }
    }

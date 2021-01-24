    public static class MyStringExtensions
    {
        public static string S(this string text, int i)
        {
            return i == 1 ? "" : text;
        }
    }

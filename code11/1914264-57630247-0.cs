    public static class StringExtensions
    {
        public static int ToInt32(this string s) =>
            int.TryParse(s, out var i) ?  i : 0;
    }

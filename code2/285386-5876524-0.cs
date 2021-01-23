    public static class StringExtensions
    {
        public static string GetCommonPrefix(string a, string b)
        {
            var result = a.TakeWhile((x, y) => b[y] == x).ToArray();
            return new string(result);
        }
    
        public static string GetCommonPrefix(params string[] strings)
        {
            return strings.Aggregate(GetCommonPrefix);
        }
    }

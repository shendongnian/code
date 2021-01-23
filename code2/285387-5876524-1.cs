    public static class StringExtensions
    {
        public static string GetCommonPrefix(string a, string b)
        {
            int commonPrefixLength = 0;
            int minimumLength = Math.Min(a.Length, b.Length);
            for (int i = 0; i < minimumLength; i++)
            {
                if (a[i] == b[i])
                {
                    commonPrefixLength++;
                }
            }
            return a.Substring(0, commonPrefixLength);
        }
    
        public static string GetCommonPrefix(params string[] strings)
        {
            return strings.Aggregate(GetCommonPrefix);
        }
    }

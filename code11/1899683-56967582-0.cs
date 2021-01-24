    public static class StringExtensions
    {
        public static bool EndIsTheBegginingOf(this string s1, string s2)
        {
            for (int i = s1.Length - 1; i >= 0; i--)
            {
                var part = s1.Substring(i);
                if (s2.StartsWith(part)) return true;
            }
    
            return false;
        }
    }

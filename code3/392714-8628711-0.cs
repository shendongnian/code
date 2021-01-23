    public static class StringExtensions
    {
        public static bool EqualsAny(this string s, params string[] args)
        {
            return args.Contains(s);
        }
    
    }

    internal static class StringExtensions
    
        {
            public static bool ContainsExt(this String str, string val)
            {
                return str.IndexOf(val, StringComparison.InvariantCultureIgnoreCase) > -1 ? true : false;
            }
        }

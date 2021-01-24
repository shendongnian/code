    public static class StringExtensions
    {
        private static char[] invalidChars = { '<', '>', '&', '%', ';', '=', '{', '}', '(', ')' };
    
        public static bool IsValid(this string value)
        {
            if (value == null)
            {
                return false;
            }
    
            foreach (char c in invalidChars)
            {
                if (value.Contains(c))
                {
                    return false;
                }
            }
    
            return true;
        }
    }

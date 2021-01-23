    public static class StringExtensions
    {
        public static string ReplaceNonAlphanumeric(this string text, char replaceChar)
        {
            StringBuilder result = new StringBuilder(text.Length);
            foreach(char c in text)
            {
                if(c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' || c >= '0' && c <= '9')
                    result.Append(c);
                else
                    result.Append(replaceChar);
            }
            return result.ToString();
        } 
    }

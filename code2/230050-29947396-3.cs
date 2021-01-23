    public static class StringExtensions
    {
        public static string RemoveTextAfterLastChar(this string text, char c)
        {
            int lastIndexOfSeparator;
            
            if (!String.IsNullOrEmpty(text) && 
                ((lastIndexOfSeparator = text.LastIndexOf(c))  > -1))
            {
                return text.Remove(lastIndexOfSeparator);
            }
            else
            {
                return text;
            }
        }
     }

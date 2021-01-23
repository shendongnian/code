    public static class StringExtensions
    {
        public static string RemoveTextAfterLastChar(this string text, char separator)
        {
            if (String.IsNullOrWhiteSpace(text) || !text.Contains(separator))
            {
                return text;
            }
            else
            {
                return text.Remove(text.LastIndexOf(separator));
            }
        }
     }

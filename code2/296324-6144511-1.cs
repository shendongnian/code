    public static class MyStringExtensions
    {
        public static string Append(this string original, string textToAdd, int length)
        {
            if (length <= 0)
            {
                return original;
            }
    
            var len = (textToAdd.Length < length)
                          ? textToAdd.Length
                          : length;
    
            return original + textToAdd.Substring(0, len);
        }
    }

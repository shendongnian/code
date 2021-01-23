    namespace Utils
    {
        public static class StringExtension
        {
            public static int NonWhitespaceLength(this string text)
            {
                return text == null ? 0 : text.Replace(" ","").Length;
            }
        }
    }

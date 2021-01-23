    public static class StringExtensions
    {
        public static IEnumerable<string> SplitToSubstrings(this string str)
        {
            int startIndex = 0;
            bool isInQuotes = false;
            for (int index = 0; index < str.Length; index++ )
            {
                if (str[index] == '\"')
                    isInQuotes = !isInQuotes;
                bool isStartOfNewSubstring = (!isInQuotes && str[index] == ',');                
                if (isStartOfNewSubstring)
                {
                    yield return str.Substring(startIndex, index - startIndex).Trim();
                    startIndex = index + 1;
                }
            }
            yield return str.Substring(startIndex).Trim();
        }
    }

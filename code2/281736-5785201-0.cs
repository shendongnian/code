    public static class StringExt
    {
        public static IEnumerable<char> DoubleChar(this IEnumerable<char> inString,
                                                   char dupChar)
            {
    
             foreach (char c in inString)
             {
                yield return c;
                if (c == dupChar)
                {
                    yield return c;
                }
             }
        }
    }

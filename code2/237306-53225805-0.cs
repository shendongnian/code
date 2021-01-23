        private static string[] SplitStringKeepDelimiters(string toSplit, char[] delimiters, StringSplitOptions splitOptions = StringSplitOptions.None)
        {
            var tokens = new List<string>();
            int idx = 0;
            for (int i = 0; i < toSplit.Length; ++i)
            {
                if (delimiters.Contains(toSplit[i]))
                {
                    int tokenLen = i - idx;
                    if (ShouldAddToken(tokenLen, splitOptions))
                    {
                        tokens.Add(toSplit.Substring(idx, tokenLen));  // token found
                    }
                    tokens.Add(toSplit[i].ToString());          // delimiter
                    idx = i + 1;                                // start idx for the next token
                }
            }
            if (ShouldAddToken(toSplit.Length - idx, splitOptions))
            {
                tokens.Add(toSplit.Substring(idx));
            }
            return tokens.ToArray();
        }
        private static bool ShouldAddToken(int tokenLen, StringSplitOptions splitOptions)
        {
            // NOT(empty string && RemoveEmptyEntities)
            return !(tokenLen == 0 && splitOptions == StringSplitOptions.RemoveEmptyEntries);
        }

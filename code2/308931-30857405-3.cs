    public static string RemoveExtraWhitespace(string str)
        {
            var sb = new StringBuilder();
            var prevIsWhitespace = false;
            foreach (var ch in str)
            {
                var isWhitespace = char.IsWhiteSpace(ch);
                if (prevIsWhitespace && isWhitespace)
                {
                    continue;
                }
                sb.Append(ch);
                prevIsWhitespace = isWhitespace;
            }
            return sb.ToString();
        }

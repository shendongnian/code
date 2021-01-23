    public static string GetTextWithNewLines(string value = "", int charactersToWrapAt = 35, int maxLength = 250)
            {
                if (string.IsNullOrWhiteSpace(value)) return "";
    
                value = value.Replace("  ", " ");
                var words = value.Split(' ');
                var sb = new StringBuilder();
                var currString = new StringBuilder();
    
                foreach (var word in words)
                {
                    if (currString.Length + word.Length + 1 < charactersToWrapAt) // The + 1 accounts for spaces
                    {
                        sb.AppendFormat(" {0}", word);
                        currString.AppendFormat(" {0}", word);
                    }
                    else
                    {
                        currString.Clear();
                        sb.AppendFormat("{0}{1}", Environment.NewLine, word);
                        currString.AppendFormat(" {0}", word);
                    }
                }
    
                if (sb.Length > maxLength)
                {
                    return sb.ToString().Substring(0, maxLength) + " ...";
                }
    
                return sb.ToString().TrimStart().TrimEnd();
            }

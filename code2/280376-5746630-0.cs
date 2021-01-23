    private string PlaceQuotes(string str, int startPosition, int lastPosition)
            {
                string quotedString = string.Empty;
                string replacedString = str.Replace(str.Substring(0, startPosition),str.Substring(0, startPosition).Insert(startPosition, "'")).Substring(0, lastPosition).Insert(lastPosition, "'");
                return String.Concat(replacedString, str.Remove(0, replacedString.Length));
            }

        public static string LimitText(string input, int width)
        {
            const string pattern = @"(</?[a-zA-Z0-9 '=://.]+>)";  
            
            var rgx = new Regex(pattern, RegexOptions.Compiled);  
            // remove tags and chop text to set width
            var result = rgx.Replace(input, string.Empty).Substring(0, width);
            // split till word boundary (so that "shittake" doesn't end up as "shit")
            result = result.Substring(0, result.LastIndexOf(' '));
            var matches = rgx.Matches(input);
            // non LINQ version to keep things simple
            foreach (Match match in matches)
            {
                var groups = match.Groups;
                if (groups[0].Index > result.Length) break;
                result = result.Insert(groups[0].Index, groups[0].Value);
            }
            // check for unbalanced tags
            matches = rgx.Matches(result);
            if (matches.Count % 2 != 0)
            {
                // chop off unbalanced tag
                return result.Substring(0, matches[matches.Count-1].Groups[0].Index);
            }
            return result;
        }

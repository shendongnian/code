        public static string[] SplitAt(this string text, params int[] indexes)
        {
            var pattern = new StringBuilder();
            var lastIndex = 0;
            foreach (var index in indexes)
            {
                pattern.AppendFormat("(.{{{0}}})", index - lastIndex);
                lastIndex = index;
            }
            pattern.Append("(.+)");
            
            var match = new Regex(pattern.ToString()).Match(text);
            if (! match.Success)
            {
                throw new ArgumentException("text cannot be split by given indexes");
            }
            var result = new string[match.Groups.Count - 1];
            for (var i = 1; i < match.Groups.Count; i++)
                result[i - 1] = match.Groups[i].Value;
            return result;            
        }

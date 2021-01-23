    public class MyMarkup
    {
        // These are used to build up the regex.
        const string RegexInnerText = @"<{0}\s*(?>(?<aname>\w*?)\s*=\s*""(?<aval>[^""]*)""\s*)*>(?<itext>.*?)</{0}>";
        const string RegexNoInnerText = @"<{0}\s*(?>(?<aname>\w*?)\s*=\s*""(?<aval>[^""]*)""\s*)*/>";
        private static LinkedList<Tuple<Regex, MatchEvaluator>> _replacers = new LinkedList<Tuple<Regex, MatchEvaluator>>();
        static MyMarkup()
        {
            Register("year", false, tok =>
            {
                var count = tok.GetInteger("digits", 4);
                var yr = DateTime.Now.Year.ToString();
                if (yr.Length > count)
                    yr = yr.Substring(yr.Length - count);
                return yr;
            });
        }
        private static void Register(string tagName, bool supportsInnerText, Func<Token, string> replacement)
        {
            var eval = CreateEvaluator(replacement);
            // Add the no inner text variant.
            _replacers.AddLast(Tuple.Create(CreateRegex(tagName, RegexNoInnerText), eval));
            // Add the inner text variant.
            if (supportsInnerText)
                _replacers.AddLast(Tuple.Create(CreateRegex(tagName, RegexInnerText), eval));
        }
        private static Regex CreateRegex(string tagName, string format)
        {
            return new Regex(string.Format(format, Regex.Escape(tagName)), RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
        public static string Execute(string input)
        {
            foreach (var replacer in _replacers)
                input = replacer.Item1.Replace(input, replacer.Item2);
            return input;
        }
        private static MatchEvaluator CreateEvaluator(Func<Token, string> replacement)
        {
            return match =>
            {
                // Grab the groups/values.
                var aname = match.Groups["aname"];
                var aval = match.Groups["aval"];
                var itext = match.Groups["itext"].Value;
                
                // Turn aname and aval into a KeyValuePair.
                var attrs = Enumerable.Range(0, aname.Captures.Count)
                    .Select(i => new KeyValuePair<string, string>(aname.Captures[i].Value, aval.Captures[i].Value));
                
                return replacement(new Token(itext, attrs));
            };
        }
    }

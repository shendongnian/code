    class Parser
    {
        private static readonly Regex TemplateRegex =
            new Regex(@"\[%(?<field>[^]]+)%\](?<delim>[^[]+)?");
        readonly List<string> m_fields = new List<string>();
        private readonly Regex m_textRegex;
        public Parser(string template)
        {
            var textRegexString = '^' + TemplateRegex.Replace(template, Evaluator) + '$';
            m_textRegex = new Regex(textRegexString);
        }
        string Evaluator(Match match)
        {
            // add field name to collection and create regex for the field
            var fieldName = match.Groups["field"].Value;
            m_fields.Add(fieldName);
            string result = "(.*?)";
            // add delimiter to the regex, if it exists
            // TODO: check, that only last field doesn't have delimiter
            var delimGroup = match.Groups["delim"];
            if (delimGroup.Success)
            {
                string delim = delimGroup.Value;
                result += Regex.Escape(delim);
            }
            return result;
        }
        public IDictionary<string, string> Parse(string text)
        {
            var match = m_textRegex.Match(text);
            var groups = match.Groups;
            var result = new Dictionary<string, string>(m_fields.Count);
            for (int i = 0; i < m_fields.Count; i++)
                result.Add(m_fields[i], groups[i + 1].Value);
            return result;
        }
    }

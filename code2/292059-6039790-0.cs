    public class Parser
    {
        private Regex regex;
        public Parser(string someRegex)
        {
            regex = new Regex(someRegex, RegexOptions.Compiled);
        }
        public string ParseSomethingCool(string text)
        {
            return regex.Match(text).Value;
        }
    }

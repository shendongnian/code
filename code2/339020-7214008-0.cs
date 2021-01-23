    public class PrefixedNumber
    {
        private static Regex parser = new Regex(@"^(\p{L}+)(\d+)$");
        public PrefixedNumber(string source) // you may want a static Parse method.
        {
            Match parsed = parser.Match(source); // think about an error here when it doesn't match
            Prefix = parsed.Groups[1].Value;
            Index = parsed.Groups[2].Value;
        }
        public string Prefix { get; set; }
        public string Index { get; set; }
    }

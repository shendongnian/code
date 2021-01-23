    public class TagReplacer
    {
        Dictionary<string, MvcHtmlString> tokenmap;
        public string Value { get; set; } 
    
        public TagReplacer(string text, Dictionary<string, MvcHtmlString> tokenMap)
        {
            tokenmap = tokenMap;
    
            Regex re = new Regex(@"\[.*?\]", RegexOptions.IgnoreCase);
            Value = re.Replace(text, new MatchEvaluator(this.Replacer));
        }
    
        public string Replacer(Match m)
        {
            return tokenmap[m.Value.RemoveSet("[]")].ToString();
        }
    
        public MvcHtmlString ToMvcHtmlString()
        {
            return MvcHtmlString.Create(Value);
        }
    }

    public List<IRule> GetListOfRules()
    {
        var rulesElement = XElement.Parse(@"<rules>
            <autoStart></autoStart>
            <noMore></noMore>
            <unExpectedCrush></unExpectedCrush>
        </rules>");
        
        var listOfRulesFromElement = 
            rulesElement.Elements().Select(d => new Rule { RuleName = d.Name.LocalName }).ToList<IRule>();
        return listOfRulesFromElement;
    }
    
    public class Rule : IRule
    {
        public string RuleName { get; set; }
        public string GetRule()
        {
            return RuleName;
        }
    }
    public interface IRule
    {
        string GetRule();
    }

    public List<IRule> GetListOfRules()
    {
        var rulesElement = XElement.Parse(@"<rules>
            <autoStart></autoStart>
            <noMore></noMore>
            <unExpectedCrush></unExpectedCrush>
        </rules>");
        
        var listOfRulesFromElement = 
            rulesElement.Elements().Select(d =>
            {
                var parsed = Enum.TryParse(d.Name.LocalName, out RuleType ruleName);
                if (!parsed)
                    ruleName = RuleType.UnmappedRule;
                return new Rule {RuleName = ruleName};
            }).ToList<IRule>();
        return listOfRulesFromElement;
    }
    public class Rule : IRule
    {
        public RuleType RuleName { get; set; }
        public RuleType GetRule()
        {
            return RuleName;
        }
    }
    public enum RuleType
    {
        UnmappedRule,
        AutoStart,
        NoMore,
        UnExpectedCrush
    }
    public interface IRule
    {
        RuleType GetRule();
    }

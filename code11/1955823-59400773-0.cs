    public delegate bool RuleEvaluator(Data data, DataType dataType);
    internal class InlineRule : Rule
    {
        private RuleEvaluator _ruleEvaluator;
        public InlineRule(RuleEvaluator ruleEvaluator)
        {
            _ruleEvaluator = ruleEvaluator;
        }
        public override bool IsSatisfied(Data data, DataType dataType)
            => _ruleEvaluator(data, dataType);
    }
    public class Definition
    {
        ... code as before...
        public Definition SetRule(RuleEvaluator ruleEvaluator)
        {
            _rule = new InlineRule(ruleEvaluator);
            return this;
        }
    }

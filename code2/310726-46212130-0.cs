    public class RuleExpression
    {
        public NodeOperator NodeOperator { get; set; }
        public List<RuleExpression> Expressions { get; set; }
        public Rule Rule { get; set; }
        public RuleExpression()
        {
                
        }
        public RuleExpression(Rule rule)
        {
            NodeOperator = NodeOperator.Leaf;
            Rule = rule;
        }
        public RuleExpression(NodeOperator nodeOperator, List<RuleExpression> expressions, Rule rule)
        {
            this.NodeOperator = nodeOperator;
            this.Expressions = expressions;
            this.Rule = rule;
        }
    }
    public enum NodeOperator
    {
        And,
        Or,
        Leaf
    }

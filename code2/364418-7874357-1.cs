    public class LiteralExpression : Expression
    {
        private float value;
        public LiteralExpression(float x)
            : base(null, null) { } // should not have any linked expressions
        
        public override float Evaluate()
        {
            return value;
        }
    }

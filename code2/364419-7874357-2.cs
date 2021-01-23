    public class AdditionExpression : Expression
    {
        public AdditionExpression(Expression x, Expression y)
            : base(x, y) { };
        public override float Evaluate()
        {
            return lhs.Evaluate() + rhs.Evaluate();
        }
    }

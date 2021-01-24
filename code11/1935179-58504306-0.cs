    public class ReplaceParameterVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression match;
        private readonly Expression replacement;
        public ReplaceParameterVisitor(ParameterExpression match, Expression replacement)
        {
            this.match = match ?? throw new ArgumentNullException(nameof(match));
            this.replacement = replacement ?? throw new ArgumentNullException(nameof(replacement));
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == this.match ? this.replacement : base.VisitParameter(node);
        }
    }

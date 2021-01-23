    class ExpressionSubstitute : ExpressionVisitor
    {
        public readonly Expression from, to;
        public ExpressionSubstitute(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        public override Expression Visit(Expression node)
        {
            if (node == from) return to;
            return base.Visit(node);
        }
    }

    public class DecryptByKeyExpression : Expression
    {
        private readonly Expression _value;
        public override ExpressionType NodeType => ExpressionType.Extension;
        public override Type Type => typeof(string);
        public override bool CanReduce => false;
        protected override Expression VisitChildren(ExpressionVisitor visitor)
        {
            var visitedValue = visitor.Visit(_value);
            if (ReferenceEquals(_value, visitedValue))
            {
                return this;
            }
            return new DecryptByKeyExpression(visitedValue);
        }
        protected override Expression Accept(ExpressionVisitor visitor)
        {
            if (!(visitor is IQuerySqlGenerator))
            {
                return base.Accept(visitor);
            }
            visitor.Visit(new SqlFragmentExpression("CONVERT(VARCHAR(MAX), DECRYPTBYKEY("));
            visitor.Visit(_value);
            visitor.Visit(new SqlFragmentExpression("))"));
            return this;
        }
        public DecryptByKeyExpression(Expression value)
        {
            _value = value;
        }
    }

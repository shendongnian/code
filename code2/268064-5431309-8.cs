    class ParameterVisitor : ExpressionVisitor
    {
        private readonly ReadOnlyCollection<ParameterExpression> from, to;
        public ParameterVisitor(
            ReadOnlyCollection<ParameterExpression> from,
            ReadOnlyCollection<ParameterExpression> to)
        {
            if(from == null) throw new ArgumentNullException("from");
            if(to == null) throw new ArgumentNullException("to");
            if(from.Length != to.Length) throw new InvalidOperationException(
                 "Parameter lengths must match");
            this.from = from;
            this.to = to;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            for (int i = 0; i < from.Count; i++)
            {
                if (node == from[i]) return to[i];
            }
            return node;
        }
    }
    public static Expression<Func<T, bool>> AndAlso<T>(
          Expression<Func<T, bool>> x, Expression<Func<T, bool>> y)
    {
        var newY = new ParameterVisitor(y.Parameters, x.Parameters)
                  .VisitAndConvert(y.Body, "AndAlso");
        return Expression.Lambda<Func<T, bool>>(
            Expression.AndAlso(x.Body, newY),
            x.Parameters);
    }

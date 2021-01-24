    public class OptionalCallFix : ExpressionVisitor
    {
        private readonly List<Expression> _conditionalExpressions = new List<Expression>();
        private readonly Type _contextType;
        private readonly Type _entityType;
        private OptionalCallFix(Type contextType, Type entityType)
        {
            this._contextType = contextType;
            this._entityType = entityType;
        }
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            // Replace Queryable.Union(left, right) call with:
            //     left == null && right == null ? new Entity[0] : (left == null ? right : (right == null ? left : Queryable.Union(left, right)))
            if (node.Method.DeclaringType == typeof(Queryable) && node.Method.Name == nameof(Queryable.Union))
            {
                Expression left = this.Visit(node.Arguments[0]);
                Expression right = this.Visit(node.Arguments[1]);
                // left == null
                Expression leftIsNull = Expression.Equal(left, Expression.Constant(null, left.Type));
                
                // right == null
                Expression rightIsNull = Expression.Equal(right, Expression.Constant(null, right.Type));
                // new Entity[0].AsQueryable()
                Expression emptyArray = Expression.Call
                (
                    typeof(Queryable),
                    nameof(Queryable.AsQueryable),
                    new [] { this._entityType },
                    Expression.NewArrayInit(this._entityType, new Expression[0])
                );
                
                // left == null && right == null ? new Entity[0] : (left == null ? right : (right == null ? left : Queryable.Union(left, right)))
                return Expression.Condition
                (
                    Expression.AndAlso(leftIsNull, rightIsNull),
                    emptyArray,
                    Expression.Condition
                    (
                        leftIsNull,
                        right,
                        Expression.Condition
                        (
                            rightIsNull,
                            left,
                            Expression.Call
                            (
                                typeof(Queryable), 
                                nameof(Queryable.Union), 
                                new [] { this._entityType }, 
                                left, 
                                Expression.Convert(right, typeof(IEnumerable<>).MakeGenericType(this._entityType))
                            )
                        )
                    )
                );
            }
            
            return base.VisitMethodCall(node);
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            Expression expression = this.Visit(node.Expression);
            
            // Check if expression should be fixed
            if (this._conditionalExpressions.Contains(expression))
            {
                // replace e.XXX with e == null ? null : e.XXX
                ConditionalExpression condition = Expression.Condition
                (
                    Expression.Equal(expression, Expression.Constant(null, expression.Type)),
                    Expression.Constant(null, node.Type),
                    Expression.MakeMemberAccess(expression, node.Member)
                );
                
                // Add fixed expression to the _conditionalExpressions list
                this._conditionalExpressions.Add(condition);
                return condition;
            }
            
            return base.VisitMember(node);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node.Type == this._contextType)
            {
                // Add ParameterExpression to the _conditionalExpressions list
                // It is used in VisitMember method to check if expression should be fixed this way
                this._conditionalExpressions.Add(node);
            }
            
            return base.VisitParameter(node);
        }
        public static IQueryable<TEntity> Fix<TContext, TEntity>(TContext context, in Expression<Func<TContext, IQueryable<TEntity>>> method)
        {
            return ((Expression<Func<TContext, IQueryable<TEntity>>>)new OptionalCallFix(typeof(TContext), typeof(TEntity)).Visit(method)).Compile().Invoke(context);
        }
    }

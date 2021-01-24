    public static class MapperExtensions
    {
        public static Expression<Func<TEntity, bool>> ConvertPredicate<TDto, TEntity>(this Mapper mapper, Expression<Func<TDto, bool>> predicate)
        {
            return (Expression<Func<TEntity, bool>>)new PredicateVisitor<TDto, TEntity>(mapper).Visit(predicate);
        }
        public class PredicateVisitor<TDto, TEntity> : ExpressionVisitor
        {
            private readonly ParameterExpression _entityParameter;
            private readonly MemberAssignment[] _bindings;
            
            public PredicateVisitor(Mapper mapper)
            {
                IQueryable<TDto> mockQuery = mapper.ProjectTo<TDto>(new TEntity[0].AsQueryable(), null);
                LambdaExpression lambdaExpression = (LambdaExpression)((UnaryExpression)((MethodCallExpression) mockQuery.Expression).Arguments[1]).Operand;
                
                this._bindings = ((MemberInitExpression)lambdaExpression.Body).Bindings.Cast<MemberAssignment>().ToArray();
                this._entityParameter = Expression.Parameter(typeof(TEntity));
            }
            // This is required to modify type parameters
            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                return Expression.Lambda(
                    base.Visit(node.Body),
                    node.Parameters.Select(p => (ParameterExpression)base.Visit(p)).ToArray()
                );
            }
            
            // Do member mapping
            protected override Expression VisitMember(MemberExpression node)
            {
                MemberInfo member = node.Member;
                MemberAssignment binding = this._bindings.FirstOrDefault(b => b.Member == member);
                if (binding != null)
                {
                    return base.Visit(binding.Expression);
                }
                
                return base.VisitMember(node);
            }
            // Replace parameters reference
            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (node.Type == typeof(TDto))
                {
                    return this._entityParameter;
                }
                if (node.Type == typeof(TEntity))
                {
                    return this._entityParameter;
                }
                
                return base.VisitParameter(node);
            }
        }
    }

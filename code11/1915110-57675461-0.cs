    public class ReplaceToExpandoVisitor<TSource> : ExpressionVisitor
    {
        private static readonly PropertyInfo ItemProperty = typeof(IDictionary<string, object>).GetProperty("Item");
        
        private readonly ParameterExpression _targetParameter = Expression.Parameter(typeof(ExpandoObject));
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            var body = this.Visit(node.Body);
            var parameters = node.Parameters.Select(this.Visit).Cast<ParameterExpression>();
            
            return Expression.Lambda(body, parameters);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node.Type == typeof(TSource))
            {
                return this._targetParameter;
            }
            
            return node;
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.MemberType != MemberTypes.Property)
            {
                throw new NotSupportedException();
            }
            string memberName = node.Member.Name;
            
            return Expression.Convert(
                Expression.Property(
                    this.Visit(node.Expression),
                    ItemProperty, 
                    Expression.Constant(memberName)
                ), 
                ((PropertyInfo)node.Member).PropertyType
            );
        }
    }

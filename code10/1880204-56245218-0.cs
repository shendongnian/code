    public static class SpecificationExtensions
    {
    	public static Expression ApplySpecifications(this Expression source) =>
    		new SpecificationsProcessor().Visit(source);
    
    	class SpecificationsProcessor : ExpressionVisitor
    	{
    		protected override Expression VisitMember(MemberExpression node)
    		{
    			if (node.Expression != null && node.Member is PropertyInfo property)
    			{
    				var info = property.GetCustomAttribute<SpecificationAttribute>();
    				if (info != null)
    				{
    					var type = property.DeclaringType;
    					var specificationMemberInfo = type.GetFields(BindingFlags.Static | BindingFlags.Public)
    						.Single(x => x.Name == info.FieldName);
    					var specification = (BaseSpecification)specificationMemberInfo.GetValue(null);
    					var specificationExpression = (LambdaExpression)specification.ToExpression();
    					var expression = specificationExpression.Body.ReplaceParameter(
    						specificationExpression.Parameters.Single(), Visit(node.Expression));
    					return Visit(expression);
    				}
    			}
    			return base.VisitMember(node);
    		}
    	}
    }

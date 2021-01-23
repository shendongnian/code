    public void CustomMethod(Expression<Func<TSource, object>> method)
    {
         PropertyFinder lister = new PropertyFinder();
         properties = lister.Parse((Expression) expr);
    }
    // this will be what you want to return from GetPropertiesUsed
    List<string> properties;
    
    public class PropertyFinder : ExpressionVisitor
    {
        public List<string> Parse(Expression expression)
        {
            properties.Clear();
            Visit(expression);
            return properties;
        }
        List<string> properties = new List<string>();
    
        protected override Expression VisitMember(MemberExpression m)
        {
            // look at m to see what the property name is and add it to properties
            ... code here ...
            // then return the result of ExpressionVisitor.VisitMember
            return base.VisitMember(m);
        }
    }

    public static PaginaCollector SlimWhere(this PaginaCollector paginaCollector, Expression<Func<WhereDummy, bool>> expression)
    {
        var mainExpression = expression.Body as BinaryExpression;
        SubSonic.Where result = ParseFilter(mainExpression);
        switch (mainExpression.NodeType)
        {
            case ExpressionType.Equal:        
                result.Comparison = Comparison.Equals;
                break;
            
            ...
            
            default:
                throw new NotImplementedException();
        }
        return paginaCollector.Where(result);
    }

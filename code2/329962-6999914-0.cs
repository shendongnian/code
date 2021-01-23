    class Visitor : ExpressionVisitor {
      protected override Expression VisitBinary( BinaryExpression node ) {
        var memberLeft = node.Left as MemberExpression;
        if ( memberLeft != null && memberLeft.Expression is ParameterExpression ) {
          var f = Expression.Lambda( node.Right ).Compile();
          var value = f.DynamicInvoke();
          }
        return base.VisitBinary( node );
        }
      }

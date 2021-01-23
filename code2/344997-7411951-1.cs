    public abstract class QueryModifier : ExpressionVisitor
    {
      private bool OrganizedOrdering { get; set; }
      protected override Expression VisitMethodCall(MethodCallExpression node)
      {
        if (node.Method.Name == "ToString" && node.Method.DeclaringType == typeof(object))
        {
          try
          {
            //If the object calling ToString is parameterless, invoke the method and convert it into a constant.
            return Expression.Constant(Expression.Lambda(node).Compile().DynamicInvoke());
          }
          catch (InvalidOperationException)
          {
            throw new InvalidOperationException("ToString() can only be translated into SQL when used on parameterless expressions.");
          }
        }
        else if (IsOrderStatement(node.Method))
        {
          if (!OrganizedOrdering)
          {
            OrganizedOrdering = true;
            return RearrangeOrderStatements(node);
          }
          else
            return base.VisitMethodCall(node);
        }
        else if (OrganizedOrdering && !IsOrderCommutative(node.Method))
        {
          OrganizedOrdering = false;
          return base.VisitMethodCall(node);
        }
        else
        {
          return base.VisitMethodCall(node);
        }
      }
      private Expression RearrangeOrderStatements(MethodCallExpression node)
      {
        //List to store (OrderBy expression, position) tuples
        List<Tuple<MethodCallExpression, double>> orderByExpressions = new List<Tuple<MethodCallExpression, double>>();
        double low = 0;
        double high = 1;
        MethodCallExpression startNode = node;
        Expression lastNode = node.Arguments[0];
        //Travel down the chain and store all OrderBy and ThenBy statements found with their relative positions
        while (node != null && node.Method.DeclaringType == typeof(System.Linq.Queryable))
        {
          if (node.Arguments.Count == 0)
            break;
          if (node.Method.Name.StartsWith("OrderBy"))
          {
            orderByExpressions.Add(new Tuple<MethodCallExpression, double>(node, low));
            low = low + 1;
            high = low + 1;
          }
          else if (node.Method.Name.StartsWith("ThenBy"))
          {
            double pos = (high - low) * 0.9 + low;
            orderByExpressions.Add(new Tuple<MethodCallExpression, double>(node, pos));
            high = pos;
          }
          else if (!IsOrderCommutative(node.Method))
          {
            break;
          }
          lastNode = node.Arguments[0];
          node = lastNode as MethodCallExpression;
        }
        lastNode = startNode;
        var methods = typeof(Queryable).GetMethods().Where(o => IsOrderStatement(o));
        Type queryType = startNode.Arguments[0].Type.GetGenericArguments()[0];
        bool firstStatement = true;
        foreach (var tuple in orderByExpressions.OrderBy(o => o.Item2))
        {
          string methodName;
          if (firstStatement)
          {
            methodName = "OrderBy";
            firstStatement = false;
          }
          else
            methodName = "ThenBy";
          if (tuple.Item1.Method.Name.EndsWith("Descending"))
            methodName = methodName + "Descending";
          Type orderByTValueType = tuple.Item1.Arguments[1].Type.GetGenericArguments()[0].GetGenericArguments()[1];
          if (tuple.Item1.Arguments.Count == 3)
          {
            var method = methods.Single(o => o.Name == methodName && o.GetParameters().Length == 3)
              .MakeGenericMethod(queryType, orderByTValueType);
            lastNode = Expression.Call(method, lastNode, tuple.Item1.Arguments[1], tuple.Item1.Arguments[2]);
          }
          else
          {
            var method = methods.Single(o => o.Name == methodName && o.GetParameters().Length == 2)
              .MakeGenericMethod(queryType, orderByTValueType);
            lastNode = Expression.Call(method, lastNode, tuple.Item1.Arguments[1]);
          }
        }
        return Visit(lastNode);
      }
      /// <summary>
      /// Returns true if the given method call expression is commutative with OrderBy statements.
      /// </summary>
      /// <param name="expression"></param>
      /// <returns></returns>
      private bool IsOrderCommutative(MethodInfo method)
      {
        return new string[] { "Where", "Distinct", "AsQueryable" }.Contains(method.Name)
          && method.DeclaringType == typeof(System.Linq.Queryable);
      }
      private bool IsOrderStatement(MethodInfo method)
      {
        return (method.Name.StartsWith("OrderBy") || method.Name.StartsWith("ThenBy"))
          && method.DeclaringType == typeof(System.Linq.Queryable);
      }
    }

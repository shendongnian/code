    string GetColumnName<T,TResult>(Expression<Func<T,TResult>> property)
    {
        var member = GetMemberExpression(property.Body);
        if (member == null)
            throw new ArgumentException("Not reducible to a Member Access", 
                                        "property");
        return member.Member.Name;
    }
    MemberExpression GetMemberExpression(Expression body)
    {
        var candidates = new Queue<Expression>();
        candidates.Enqueue(body);
        while (candidates.Count > 0)
        {
            var expr = candidates.Dequeue();
            if (expr is MemberExpression)
            {
                return ((MemberExpression)expr);
            }
            else if (expr is UnaryExpression)
            {
                candidates.Enqueue(((UnaryExpression)expr).Operand);
            }
            else if (expr is BinaryExpression)
            {
                var binary = expr as BinaryExpression;
                candidates.Enqueue(binary.Left);
                candidates.Enqueue(binary.Right);
            }
            else if (expr is MethodCallExpression)
            {
                var method = expr as MethodCallExpression;
                foreach (var argument in method.Arguments)
                {
                    candidates.Enqueue(argument);
                }
            }
            else if (expr is LambdaExpression)
            {
                candidates.Enqueue(((LambdaExpression)expr).Body);
            }
        }
        return null;
    }

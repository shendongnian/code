    static IEnumerable<MemberExpression> GetMemberExpressions(Expression body)
    {
        // A Queue preserves left to right reading order of expressions in the tree
        var candidates = new Queue<Expression>(new[] { body });
        while (candidates.Count > 0)
        {
            var expr = candidates.Dequeue();
            if (expr is MemberExpression)
            {
                yield return ((MemberExpression)expr);
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
    }

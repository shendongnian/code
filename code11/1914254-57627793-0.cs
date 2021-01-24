    private static Expression<Action<IInterface, IInterface>> CreateCopyMethod(Type type)
    {
        var props = type
            .GetProperties()
            .Where(p => p.IsDefined(typeof(CopyableAttribute), false))
            .ToArray();
        var s = Expression.Parameter(typeof(IInterface), "s");
        var t = Expression.Parameter(typeof(IInterface), "t");
        var source = Expression.Variable(type, "source");
        var castToSource = Expression.Assign(source, Expression.Convert(s, type));
        var target = Expression.Variable(type, "target");
        var castToTarget = Expression.Assign(target, Expression.Convert(t, type));
        var instructions = new List<Expression>
        {
            castToSource, castToTarget
        };
        foreach (var property in props)
        {
            var left = Expression.Property(target, property);
            var right = Expression.Property(source, property);
            var assign = Expression.Assign(left, right);
        
            instructions.Add(assign);
        }
        var lambda = Expression.Lambda<Action<IInterface, IInterface>>(
            Expression.Block(
                new[] {source, target}, instructions),
            s, t);
        return lambda;
    }

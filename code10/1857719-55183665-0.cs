    var i = Expression.Parameter(typeof(int), "i");
    var cnt = Expression.Variable(typeof(int), "cnt");
    var sum = Expression.Variable(typeof(int), "sum");
    var writeLineMethod = typeof(Console).GetMethod("WriteLine", new[] { typeof(object) });
    var breakLabel = Expression.Label("break");
    var loop = Expression.Loop(
        Expression.Block(
            Expression.IfThen(
                Expression.GreaterThanOrEqual(cnt, i),
                Expression.Block(
                    Expression.Call(writeLineMethod, Expression.Convert(sum, typeof(object))),
                    Expression.Break(breakLabel))),
            Expression.AddAssign(sum, cnt),
            Expression.PostIncrementAssign(cnt)),
        breakLabel);
    var block = Expression.Block(new[] { cnt, sum },
        Expression.Assign(cnt, Expression.Constant(0)),
        Expression.Assign(sum, Expression.Constant(0)),
        loop,
        sum);
    var method = Expression.Lambda<Func<int, int>>(block, new[] { i }).Compile();

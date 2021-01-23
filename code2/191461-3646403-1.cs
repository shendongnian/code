    BlockExpression block = Expression.Block(
        new ParameterExpression[] { 
            localvarnos1, localvarnos2, enumerator, currentelement },
        bexplocalnos1, 
        bexplocalnos2, 
        assignenumerator, 
        Expression.Loop(
            Expression.IfThenElse(
                Expression.NotEqual(movenext, Expression.Constant(false)),
                Expression.Block(
                    callCurrent, 
                    Expression.IfThenElse(
                        firstlessequalsecond, 
                        Expression.Assign(
                            localvarnos1, 
                            Expression.Increment(localvarnos1)), 
                        Expression.Assign(
                            localvarnos2, 
                            Expression.Increment(localvarnos2)))),
                Expression.Break(looplabel)), 
            looplabel),
        Expression.LessThan(localvarnos1, localvarnos2));
    Expression<Func<IEnumerable<int>, int, bool>> lambda = 
        Expression.Lambda<Func<IEnumerable<int>, int, bool>>(
            block,
            enumerableExpression,
            intexpression);

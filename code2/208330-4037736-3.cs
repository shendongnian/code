    var action3 =
        Expression.Lambda<Action>
        (
            Expression.Block
            (
                new [] { localVariable },
                new Expression[] {
                    Expression.Assign(localVariable, disposeExpression);
                    Using
                    (
                        localVariable,
                        bodyExpression,
                        localVariable,
                        false
                    ),
                    Expression.IfThenElse(
                        Expression.NotEqual(
                            localVariable, Expression.Constant(null)),
                        ((Expression<Action>)(() => Console.WriteLine("w is NOT null"))).Body,
                        ((Expression<Action>)(() => Console.WriteLine("w is null"))).Body
                    )
                }
            )
        );
    action3.Compile()();

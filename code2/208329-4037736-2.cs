    var action1 =
        Expression.Lambda<Action>
        (
            Using
            (
                disposableExpression,
                bodyExpression,
                localVariable
            )
        );
    action1.Compile()();
    var action2 =
        Expression.Lambda<Action>
        (
            Expression.Block
            (
                new [] { localVariable },
                new Expression[] {
                    Using
                    (
                        disposableExpression,
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
    action2.Compile()();

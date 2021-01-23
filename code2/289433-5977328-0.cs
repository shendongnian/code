    var param = Expression.Parameter<Customer>();
    p = Expression.LambdaFunc<Customer, bool>(
        Expression.Call(typeof(object), "Equals", null, //non-generic
                        Expression.Proeprty(param, columnName),
                        Expresssion.Constant(value)
        )
    );

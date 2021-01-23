    var arg = Expression.Parameter(typeof(Transaction), "transaction");
    var body = Expression.Property(arg, "PaymentMethod");
    var delegateType = typeof(Func<,>).MakeGenericType(typeof(Transaction), body.Type);
    var lambda = Expression.Lambda(delegateType, body, arg);
    var source = Expression.Parameter(typeof(IEnumerable<Transaction>), "source");
    var groups = Expression.Call(typeof(Enumerable), "GroupBy", 
                                 new Type[] { typeof(Transaction), body.Type }, 
                                 source, lambda);
    var groupByLambda = Expression.Lambda(groupByExpression, source).Compile();
    var groups = groupByLambda.DynamicInvoke(transactions);

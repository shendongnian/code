    var parts = new[] { "Ha", "Ho", "He" };
    var x = Expression.Parameter(typeof(User), "x");
    var body = 
        parts.Aggregate<string, Expression>(
            Expression.Constant(false), 
            (e, p) => 
                Expression.Or(e,
                    Expression.Or(
                        Expression.Call(
                            Expression.Property(x, "LastName"), 
                            "StartsWith", 
                            null,
                            Expression.Constant(p)),
                        Expression.Call(
                            Expression.Property(x, "FirstName"), 
                            "StartsWith", 
                            null, 
                            Expression.Constant(p)))));
    var predicate = Expression.Lambda<Func<User, bool>>(body, x);
    var result = users.Where(predicate);

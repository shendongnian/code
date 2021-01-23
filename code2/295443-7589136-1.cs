    var method = typeof (string).GetMethod("Contains", new Type[] {typeof (string)}, null);
    var lambdaParameter = Expression.Parameter(typeof(TEntity), "te");
    var filterExpression = Expression.Lambda<Func<TEntity, bool>> (
                filters.Select(filter => Expression.Call(GetDeepProperty(lambdaParameter, filter.Property),
                                                          method,
                                                          Expression.Constant(filter.Value))).
                    Where(exp => exp != null).
                    Cast<Expression>().
                    ToList().
                    Aggregate(Expression.Or), lambdaParameter);

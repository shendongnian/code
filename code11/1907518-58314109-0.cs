public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
{
    var expectedResultType = typeof(TResult).GetGenericArguments()[0];
    var executionResult = typeof(IQueryProvider)
                         .GetMethod(
                              name: nameof(IQueryProvider.Execute),
                              genericParameterCount: 1,
                              types: new[] {typeof(Expression)})
                         .MakeGenericMethod(expectedResultType)
                         .Invoke(this, new[] {expression});
    return (TResult) typeof(Task).GetMethod(nameof(Task.FromResult))
                                ?.MakeGenericMethod(expectedResultType)
                                 .Invoke(null, new[] {executionResult});
}
The `executionResult` is the evaluation of the `expression` and then is wrapped in a task (with some reflection to make it generic) `Task.FromResult(executionResult)` and returned.

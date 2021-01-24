public static void Set<TValue>(this Person person, IDictionary<string, object> dictionary, string key, Expression<Func<Person, TValue>> selector, Expression<Func<object, TValue>> transformer)
{
    if (!dictionary.TryGetValue(key, out var value))
    {
        return;
    }
    var parameterExpression = selector.Parameters.Concat(transformer.Parameters);
    var delegateExpression = Expression.Lambda<Action<Person, object>>(
        Expression.Assign(selector.Body, transformer.Body), parameterExpression
    );
    
    delegateExpression.Compile()(person, value);
}

public static Expression<Func<TElement, bool>> ReplaceParameter<TElement>
(
    Expression<Func<TElement, TElement, bool>> inputExpression,
    TElement element
)
{
    var inner = Expression.Lambda<Func<TElement, bool>>
    (
        inputExpression.Body,
        inputExpression.Parameters[1]
    );
    var outer = Expression.Lambda<Func<TElement, Expression<Func<TElement, bool>>>>
    (
        inner,
        inputExpression.Parameters[0]
    );
    var factory = outer.Compile();
    return factory(element);
}
To make it even more useful, you could save `factory` and call it every time you want to replace a parameter:
public static Func<TElement, Expression<Func<TElement, bool>>> CreateFactory<TElement>
(
    Expression<Func<TElement, TElement, bool>> inputExpression
)
{
    var inner = Expression.Lambda<Func<TElement, bool>>
    (
        inputExpression.Body,
        inputExpression.Parameters[1]
    );
    var outer = Expression.Lambda<Func<TElement, Expression<Func<TElement, bool>>>>
    (
        inner,
        inputExpression.Parameters[0]
    );
    return outer.Compile();
}
public static void Test()
{
    var factory = CreateFactory<int>((i1, i2) => i1 > i2);
    var greater5 = factory(5);
    var greater2 = factory(2);
}
What is actually happening here?  
When `inputExpression` is `(i1, i2) => i1 > i2` then `inner` would be `i1 => i1 > i2` and `outer`/`factory` would be `i2 => i1 => i1 > i2`.

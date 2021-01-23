public static IObservable&lt;TResult&gt; SmartZip&lt;TLeft, TRight, TResult&gt;(
    IObservable&lt;TLeft&gt; leftSource,
    IObservable&lt;TRight&gt; rightSource,
    Func&lt;TLeft, TRight, TResult&gt; selector)
{
    return Observable
        .Merge(
            leftSource.Select(Either&lt;TLeft, TRight&gt;.Create),
            rightSource.Select(Either&lt;TLeft, TRight&gt;.Create))
        .BufferWithCount(2)
        .Select(values =&gt;
            {
                // this case was not covered in your question,
                // but I've added it for the sake of completeness.
                if (values.Count &lt; 2)
                {
                    return default(TResult);
                }
                var first = values[0];
                var second = values[1];
                // pattern-matching in C# is really ugly.
                return first.Match(
                    left =&gt; second.Match(
                        _ =&gt; default(TResult),
                        right =&gt; selector(left, right)),
                    right =&gt; second.Match(
                        left =&gt; selector(left, right),
                        _ =&gt; default(TResult)));
            });
}

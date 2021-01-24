c#
public static void Fill<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, Action<TSource, TSource> resultSelector)
{
    var backFilled = false;
    var previous = default(TSource);
    var backFill = new List<TSource>();
    foreach (var elm in source)
    {
        if (predicate(elm))
        {
            if (!backFilled)
            {
                backFill.Add(elm);
            }
            else
            {
                resultSelector(previous, elm);
            }
        }
        else if (!backFilled)
        {
            // We've found our first element to be able to backfill with
            if (backFill.Count > 0)
            {
                backFill.Add(elm);
                backFill.Reverse();
                backFill.Fill(predicate, resultSelector);
            }
            backFilled = true;
        }
        previous = elm;
    }
}
The back-filling part is only necessary because you want the first elements to not be null as well. Without that, the code is much simpler.
Here the first parameter is a condition that I want to fill on. In your case it would be if the data `DataLoad.Price` is null. So something like:
data => data.Price == null
If that condition evaluates to true, it then calls the `handler` function with the current value and the previous value. Yours would look something like this:
(prev, curr) => curr.Price = prev.Price
Putting that all together you get:
GetSomeData().Fill<DataLoad>(
    data => data.Price == null,
    (prev, curr) => curr.Price = prev.Price
);
Here's a link to a [demo][2] that you can play around with.
**Note:** This edits the existing objects in the list in place. If this is not desired, I would recommend changing the extension method to return an `IEnumerable` and the `handler` return a `TSource`.
  [1]: https://github.com/morelinq/MoreLINQ
  [2]: https://repl.it/repls/DullJointTelephones

var result = GetSomeData() 
    // Do ordering if you want
    .OrderByDescending(d => d.DateG)
    .ThenByDescending(t => t.TimeG)
    .ThenByDescending(c1 => c1.Cat1)
    .ThenByDescending(c2 => c2.Cat2)
    // Add the filling logic with .Lag()
    .Lag(1, (current, previous) =>
    {
        if(previous != null) current.name = current.name ?? previous.name;
        return current;
    }).ToList();
The one downside to this is that it doesn't provide the "backfilling" that you might need. If you had `null` prices at the beginning of the list, those would stay null and not be filled. You could get around this by manually handling those cases or running it on the reversed list (probably not recommended). Another thing to note is that this will edit the actual objects in the list and not create new ones which I typically prefer to avoid when dealing with LINQ. You could edit the selector to change that behavior.
##Custom Extension Method:
Here's one that I came up with:
c#
public static IEnumerable<TSource> Fill<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource, TSource, TSource> resultSelector)
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
                yield return resultSelector(previous, elm);
            }
        }
        else if (!backFilled)
        {
            // We've found our first element to be able to backfill with
            for (int i = 0; i < backFill.Count; i++)
            {
                yield return resultSelector(elm, backFill[i]);
            }
            backFilled = true;
            yield return elm;
        }
        else
        {
            yield return elm;
        }
        previous = elm;
    }
}
### Usage
Here the first parameter is a condition that I want to fill on. In your case it would be if the data `DataLoad.Price` is null. So something like:
data => data.Price == null
If that condition evaluates to true, it then calls the `handler` function with the current value and the previous value. Yours would look something like this:
(prev, curr) => 
{ 
    curr.Price = prev.Price;
    return curr;
}
Putting that all together you get:
var result = GetSomeData()
    // Do ordering/filtering/grouping here
    .Fill(
        data => data.Price == null,
        (prev, curr) => 
        { 
            curr.Price = prev.Price;
            return curr;
        })
    .ToList();
Here's a link to a [demo][2] that you can play around with.
The benefit of this is that you get more control over what's happening when filling while still making the function decently generic. You could apply this to any IEnumerable and have it still work. This also does the "backfilling" which the MoreLinq query didn't do out of the box. 
**Note:** This still edits the existing objects in the list in place, but a different selector would fix that.
  [1]: https://github.com/morelinq/MoreLINQ
  [2]: https://repl.it/repls/DullJointTelephones

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
And you could use it like this:
List<FakePerson> person = new List<FakePerson>(){
    new FakePerson(){ name = null}, 
    new FakePerson(){ name = "jim"},
    new FakePerson(){ name = null},
    new FakePerson(){ name = null},
    new FakePerson(){ name = "Bob"},
    new FakePerson(){ name = null}
};
person.Fill<FakePerson>(
    curr => curr.name == null,
    (prev, curr) =>
    {
        if (prev != null) curr.name = curr.name ?? prev.name;
    }
);
Here the first parameter is a condition that I want to fill on. In this case it's if the person's name is null. In your case it would be if the data `DataLoad.Price` is null. So something like:
data => data.Price == null
If that condition evaluates to true, it then calls the `handler` function with the current value and the previous value. For my handler, if the previous person wasn't null the current person's name was null, I filled the previous person's  name in to the current person's name. Yours would look something like this:
(prev, curr) => {
    if(prev != null && curr.Price == null) curr.Price = prev.Price;
}
Putting that all together you get:
person.Fill<DataLoad>(
    data => data.Price == null,
    (prev, curr) => {
        if(prev != null && curr.Price == null) curr.Price = prev.Price;
    }
);
Here's a link to the I showed [demo][1] that you can play around with.
**Note:** This edits the existing objects in the list in place. If this is not desired, I would recommend changing the extension method to return an `IEnumerable` and the `handler` return a `TSource`. 
  [1]: https://repl.it/repls/YellowishColorfulInstances

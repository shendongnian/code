csharp
List<int> list1 = new List<int>();
List<int> list2 = new List<int>();
Console.WriteLine(list1.Equals(list2)); // False
You need to tell `DistinctBy` how you want to compare the two lists, using an `IEqualityComparer<T>` - where `T` in this case is `List<string>` (because that's the type of `BoardInformation.positionQueen`.
Here's an example of a generic `ListEqualityComparer` you could use:
csharp
using System;
using System.Collections.Generic;
using System.Linq;
public sealed class ListEqualityComparer<T> : IEqualityComparer<List<T>>
{
    private readonly IEqualityComparer<T> elementComparer;
    
    public ListEqualityComparer(IEqualityComparer<T> elementComparer) =>
        this.elementComparer = elementComparer;
    
    public ListEqualityComparer() : this(EqualityComparer<T>.Default)
    {
    }
    
    public bool Equals(List<T> x, List<T> y) =>
        ReferenceEquals(x, y) ? true
        : x is null || y is null ? false
        // Delegate to LINQ's SequenceEqual method
        : x.SequenceEqual(y, elementComparer);
    
    public int GetHashCode(List<T> obj)
    {
        if (obj is null)
        {
            return 0;
        }
        // Just a very simple hash implementation
        int hash = 23;
        foreach (var item in obj)
        {
            hash = hash * 31 +
                (item is null ? 0
                 : elementComparer.GetHashCode(item));
        }
        return hash;
    }
}
You'd then pass that to `DistinctBy`, like this:
csharp
// We're fine to use the default *element* comparer (string.Equals etc)
var comparer = new ListEqualityComparer<string>();
boardGenerate = boardGenerate.DistinctBy(x => x.positionQueen, comparer).ToList();
Now `DistinctBy` will call into the comparer, passing in the lists, and will consider your two `BoardInformation` objects are equal - so only the first will be yielded by `DistinctBy`, and you'll end up with a list containing a single item.

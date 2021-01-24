csharp
public struct Interval
{
    public Interval(int from, int to)
    {
        From = from;
        To = to;
    }
    public int From { get; }
    public int To { get; }
    public IEnumerable<int> Members() => Enumerable.Range(From, To - From + 1);
}
To get the numbers within the `Range`, you would use Numbers() function. Numbers are lazily generated, thus saving space unless you need them all.
The extension:
csharp
public static class EnumerableExtensions
{
    public static IEnumerable<Interval> GetIntervals(this IEnumerable<int> numbers)
    {
        var array = numbers.OrderBy(x => x).ToArray();
        var fromIndex = 0;
        var toIndex = fromIndex;
        for (var i = 1; i < array.Length; i++)
        {
            var current = array[i];
            if (current == array[toIndex] + 1)
            {
                toIndex++;
            }
            else if (fromIndex != toIndex)
            {
                yield return new Interval(array[fromIndex], array[toIndex]);
                fromIndex = i;
                toIndex = fromIndex;
            }
        }
        if (toIndex != fromIndex)
        {
            yield return new Interval(array[fromIndex], array[toIndex]);
        }
    }
}
The usage:
csharp
public void Demo()
{
    var list = new List<int> {1, 2, 3, 5, 6, 7, 9, 10};
    
    // 1-3, 5-7, 9-10, lazily generated
    var intervals = list.GetIntervals();
    foreach (var interval in intervals) 
    {
        // [1, 2, 3], then [5, 6, 7], then [9, 10], lazily generated
        var members = interval.Members(); 
        foreach (var numberInRange in members)
        {
            // do something with numberInRange
        }
    }
}
  [1]: https://en.wikipedia.org/wiki/Interval_(mathematics)

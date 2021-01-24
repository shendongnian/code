`
static class IEnumerableExtension
{
    public static T ElementAtRetainPos<T>(this IEnumerable<T> source, EnumeratorWithPos<T> enumeratorWithPos, int elementToFind)
    {
        if (elementToFind < enumeratorWithPos.EnumeratorPosition)
        {
            enumeratorWithPos.Enumerator = source.GetEnumerator();
        }
        for (var i = enumeratorWithPos.EnumeratorPosition; i < elementToFind; i++)
        {
            enumeratorWithPos.Enumerator.MoveNext();
        }
        enumeratorWithPos.EnumeratorPosition = elementToFind;
        return enumeratorWithPos.Enumerator.Current;
    }
    public static EnumeratorWithPos<T> GetEnumeratorWithPos<T>(this IEnumerable<T> source)
    {
        return new EnumeratorWithPos<T>()
        {
            Enumerator = source.GetEnumerator()
        };
    }
}
public class EnumeratorWithPos<T> : IDisposable
{
    private IEnumerator<T> enumerator;
    public IEnumerator<T> Enumerator
    {
        get
        {
            return enumerator;
        }
        set
        {
            enumerator = value;
            EnumeratorPosition = -1;
        }
    }
    public int EnumeratorPosition { get; set; }
    public void Dispose()
    {
        Enumerator.Dispose();
    }
}
`
How to use:
`
public static void Main()
{
    var naturalNumbers = GetNaturalNumbers();
    using (var enumeratorWithPos = naturalNumbers.GetEnumeratorWithPos())
    {
        var executionTime = GetExecutionTime(() => naturalNumbers.ElementAtRetainPos(enumeratorWithPos, 10000000));
        Console.WriteLine($"Time elapsed: {executionTime}");
        executionTime = GetExecutionTime(() => naturalNumbers.ElementAtRetainPos(enumeratorWithPos, 10000001));
        Console.WriteLine($"Time elapsed: {executionTime}");
        // force reset of enumerator by moving back to the previous
        executionTime = GetExecutionTime(() => naturalNumbers.ElementAtRetainPos(enumeratorWithPos, 10000001));
        Console.WriteLine($"Time elapsed: {executionTime}");
    }
}
public static IEnumerable<int> GetNaturalNumbers()
{
    Console.WriteLine("Running GetNaturalNumbers() from the beginning");
    for(int value = 0;; value++)
    {
        yield return value;
    }
}
public static System.TimeSpan GetExecutionTime(Action action)
{
    var stopwatch = Stopwatch.StartNew();
    action();
    stopwatch.Stop();
    return stopwatch.Elapsed;
}
`
First time it takes 00:00:00.1565686
Second request takes 00:00:00.0001373

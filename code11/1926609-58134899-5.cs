`
private static int myElementAt = -1;
private static int MyElementAt(IEnumerable<int> enumerable, IEnumerator<int> enumerator, int elementToFind)
{
    if (elementToFind < myElementAt) // element requested precedes enumerator position
    {
        myElementAt = -1;
        enumerator = enumerable.GetEnumerator();
    }
    for (var i = myElementAt; i < elementToFind; i++) enumerator.MoveNext();
    myElementAt = elementToFind;
    return enumerator.Current;
}
public static void Main()
{
    var naturalNumbers = GetNaturalNumbers();
    using (var enumerator = naturalNumbers.GetEnumerator())
    {
        var executionTime = GetExecutionTime(() => MyElementAt(naturalNumbers, enumerator, 10000000));
        Console.WriteLine($"Time elapsed: {executionTime}");
        executionTime = GetExecutionTime(() => MyElementAt(naturalNumbers, enumerator, 10000001));
        Console.WriteLine($"Time elapsed: {executionTime}");
        // force reset of enumerator by moving back to the previous
        executionTime = GetExecutionTime(() => MyElementAt(naturalNumbers, enumerator, 10000000));
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

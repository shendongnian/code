    public static IEnumerable<int> ToEnumerable(this Range range)
    {
       for (var i = range.Start.Value; i < range.End.Value; i++)
       {
           yield return i;
       }
    }
    ...
    var seq = 0..2;
    foreach (var s in seq.ToEnumerable())
    {
       System.Console.WriteLine(s);
    }
    // Output: 0, 1

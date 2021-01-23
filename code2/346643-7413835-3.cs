private static void Main(string[] args)
{
    var psource = Observable
        .Generate(1, i =&gt; i &lt; 100, i =&gt; i, i =&gt; i + 1)
        .Zip(Observable.Interval(TimeSpan.FromMilliseconds(10.0)), (i, _) =&gt; i);
    var qsource = Observable
        .Generate(1, i =&gt; i &lt; 100, i =&gt; (double)i * i, i =&gt; i + 1)
        .Zip(Observable.Interval(TimeSpan.FromMilliseconds(30.0)), (i, _) =&gt; i);
    var result = SmartZip(
        psource,
        qsource,
        (p, q) =&gt; q / p).ToEnumerable();
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
}

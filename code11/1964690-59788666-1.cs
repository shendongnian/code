private IEnumerable<Sample> CalculateMany(int n)
{
    return Enumerable.Range(0, n)
        .AsParallel() // comment this to remove parallelism
        .Select(i => { var s = new Sample(); CalculateStuff(s, max / (ulong)n); return s; })
        .ToList();
}
// Calculate some math stuff
private static void CalculateStuff(Sample s, ulong max)
{
    for (ulong i = 1; i <= max; i++)
    {
        s.A = Math.Pow(s.A, 1.2);
    }
}
Here's running CalculateMany with `n` values as 1, 2, and 4:
[![enter image description here][1]][1]
Here's what I get if not using parallelism:
[![enter image description here][2]][2]
I see similar results using `Task.Run()`:
private IEnumerable<Sample> CalculateMany(int n)
{
    var tasks = 
    Enumerable.Range(0, n)
        .Select(i => Task.Run(() => { var s = new Sample(); CalculateStuff(s, max / (ulong)n); return s; }))
        .ToArray()        ;
    Task.WaitAll(tasks);
    return tasks
        .Select(t => t.Result)
        .ToList();
}
  [1]: https://i.stack.imgur.com/jFrXr.png
  [2]: https://i.stack.imgur.com/t2m8P.png

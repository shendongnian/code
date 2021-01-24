|       Method |  Job | Runtime |       Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------- |----- |-------- |-----------:|----------:|----------:|-------:|------:|------:|----------:|
|        First |  Clr |     Clr | 1,020.6 ns | 1.5494 ns | 1.3735 ns | 0.0305 |     - |     - |     201 B |
|       Second |  Clr |     Clr |   769.6 ns | 3.3085 ns | 3.0948 ns | 0.0134 |     - |     - |      88 B |
| BasicForEach |  Clr |     Clr |   768.1 ns | 1.7016 ns | 1.5917 ns |      - |     - |     - |         - |
|        First | Core |    Core |   698.3 ns | 5.1906 ns | 4.8553 ns | 0.0229 |     - |     - |     192 B |
|       Second | Core |    Core |   637.4 ns | 0.4207 ns | 0.3935 ns | 0.0105 |     - |     - |      88 B |
| BasicForEach | Core |    Core |   711.7 ns | 2.9788 ns | 2.7864 ns |      - |     - |     - |         - |
It goes without saying that the more realistic you can make the data in the `Setup()` method, the more useful the test will be. But this gives a broad indication that there isn't an *inherent* trend.
---
 c#
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
public static class Program
{
    static void Main() => BenchmarkDotNet.Running.BenchmarkRunner.Run<MyBenchmarks>();
}
[CoreJob, ClrJob, MemoryDiagnoser]
public class MyBenchmarks
{
    [GlobalSetup]
    public void Setup()
    {
        _notes = new List<Foo>(100);
        var rand = new Random(12345);
        for (int i = 0; i < 100; i++)
        {
            _notes.Add(new Foo
            {
                cDate = rand.Next(10) <= 5 ? DateTimeOffset.MinValue : DateTime.Now,
                cBy = rand.Next(3),
            });
        }
        _context = new Context
        {
            UserContext = new UserContext
            {
                id = 42
            }
        };
    }
    private Context _context;
    private List<Foo> _notes;
    class Context
    {
        public UserContext UserContext { get; set; }
    }
    class UserContext
    {
        public int id { get; set; }
    }
    [Benchmark]
    public void First()
    {
        var notes = _notes;
        var context = _context;
        notes.Where(n => n.cBy == 0 || n.cDate == DateTimeOffset.MinValue).ToList().ForEach(n =>
        {
            if (n.cBy == 0)
                n.cBy = context.UserContext.id;
            if (n.cDate == DateTimeOffset.MinValue)
                n.cDate = DateTimeOffset.Now;
        });
    }
    [Benchmark]
    public void Second()
    {
        var notes = _notes;
        var context = _context;
        notes.ForEach(n =>
        {
            if (n.cBy == 0)
                n.cBy = context.UserContext.id;
            if (n.cDate == DateTimeOffset.MinValue)
                n.cDate = DateTimeOffset.Now;
        });
    }
    [Benchmark]
    public void BasicForEach()
    {
        var notes = _notes;
        var context = _context;
        foreach(var n in notes)
        {
            if (n.cBy == 0)
                n.cBy = context.UserContext.id;
            if (n.cDate == DateTimeOffset.MinValue)
                n.cDate = DateTimeOffset.Now;
        }
    }
}
public class Foo
{
    internal int cBy { get; set; }
    internal DateTimeOffset cDate { get; set; }
}

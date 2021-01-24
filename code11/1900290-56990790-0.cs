 c#
get => x ?? (x = val);
I'll add a timing for that...
| Method |  Job | Runtime | IsEmpty |      Mean |     Error |    StdDev |    Median |
|------- |----- |-------- |-------- |----------:|----------:|----------:|----------:|
|    Foo |  Clr |     Clr |   False | 1.9385 ns | 0.0118 ns | 0.0099 ns | 1.9400 ns |
|   Foo2 |  Clr |     Clr |   False | 0.9926 ns | 0.0226 ns | 0.0251 ns | 0.9900 ns |
|    Bar |  Clr |     Clr |   False | 1.9369 ns | 0.0075 ns | 0.0063 ns | 1.9400 ns |
|   Bar2 |  Clr |     Clr |   False | 0.9813 ns | 0.0197 ns | 0.0185 ns | 0.9900 ns |
|    Foo | Core |    Core |   False | 2.1233 ns | 0.0170 ns | 0.0159 ns | 2.1300 ns |
|   Foo2 | Core |    Core |   False | 0.9792 ns | 0.0168 ns | 0.0131 ns | 0.9800 ns |
|    Bar | Core |    Core |   False | 2.0097 ns | 0.0406 ns | 0.0595 ns | 2.0100 ns |
|   Bar2 | Core |    Core |   False | 0.9928 ns | 0.0209 ns | 0.0307 ns | 0.9900 ns |
|        |      |         |         |           |           |           |           |
|    Foo |  Clr |     Clr |    True | 1.7329 ns | 0.0195 ns | 0.0173 ns | 1.7300 ns |
|   Foo2 |  Clr |     Clr |    True | 1.7493 ns | 0.0164 ns | 0.0153 ns | 1.7400 ns |
|    Bar |  Clr |     Clr |    True | 1.7368 ns | 0.0339 ns | 0.0377 ns | 1.7200 ns |
|   Bar2 |  Clr |     Clr |    True | 1.7940 ns | 0.0323 ns | 0.0302 ns | 1.8100 ns |
|    Foo | Core |    Core |    True | 2.2878 ns | 0.0460 ns | 0.1358 ns | 2.1900 ns |
|   Foo2 | Core |    Core |    True | 2.2689 ns | 0.0456 ns | 0.0973 ns | 2.2100 ns |
|    Bar | Core |    Core |    True | 1.5600 ns | 0.0109 ns | 0.0085 ns | 1.5600 ns |
|   Bar2 | Core |    Core |    True | 1.5669 ns | 0.0165 ns | 0.0138 ns | 1.5600 ns |
Note I removed the actual `List<T>` creation to avoid overhead - it assigns to a static now.
Code:
 c#
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Linq;
public static class Program
{
    static void Main() => BenchmarkRunner.Run<MyTest>();
}
[ClrJob, CoreJob]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
public class MyTest
{
    [Params(false, true)]
    public bool IsEmpty { get; set; }
    const int OperationsPerInvoke = 10000;
    private readonly Blab[] blabs = Enumerable.Range(0, OperationsPerInvoke).Select(XmlExporterAttribute => new Blab()).ToArray();
    [IterationSetup]
    public void Reset()
    {
        if (IsEmpty)
        {
            foreach (var blab in blabs) blab.Reset();
        }
    }
    [Benchmark(OperationsPerInvoke = OperationsPerInvoke)]
    public void Foo()
    {
        for (int i = 0; i < blabs.Length; i++) _ = blabs[i].Foo;
    }
    [Benchmark(OperationsPerInvoke = OperationsPerInvoke)]
    public void Foo2()
    {
        for (int i = 0; i < blabs.Length; i++) _ = blabs[i].Foo2;
    }
    [Benchmark(OperationsPerInvoke = OperationsPerInvoke)]
    public void Bar()
    {
        for (int i = 0; i < blabs.Length; i++) _ = blabs[i].Bar;
    }
    [Benchmark(OperationsPerInvoke = OperationsPerInvoke)]
    public void Bar2()
    {
        for (int i = 0; i < blabs.Length; i++) _ = blabs[i].Bar2;
    }
}
public class Fubar { }
public class Blab
{
    static readonly List<Fubar> s_SharedList = new List<Fubar>();
    public void Reset()
    {
        _foo = _foo2 = null;
        _bar = _bar2 = null;
    }
    private List<Fubar> _foo;
    private string _bar;
    private List<Fubar> _foo2;
    private string _bar2;
    public List<Fubar> Foo
    {
        get
        {
            _foo = (_foo ?? s_SharedList);
            return _foo;
        }
        set
        {
            _foo = value;
        }
    }
    public string Bar
    {
        get
        {
            _bar = (_bar ?? string.Empty);
            return _bar;
        }
        set
        {
            _bar = value;
        }
    }
    public List<Fubar> Foo2
    {
        get
        {
            if (_foo2 == null) { _foo2 = s_SharedList; }
            return _foo2;
        }
        set
        {
            _foo2 = value;
        }
    }
    public string Bar2
    {
        get
        {
            if (_bar2 == null) { _bar2 = string.Empty; }
            return _bar2;
        }
        set
        {
            _bar2 = value;
        }
    }
}

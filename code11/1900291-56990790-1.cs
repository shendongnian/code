 c#
get => x ?? (x = val);
I'll add a timing for that...
| Method |  Job | Runtime | IsEmpty |     Mean |     Error |    StdDev |   Median |
|------- |----- |-------- |-------- |---------:|----------:|----------:|---------:|
|    Foo |  Clr |     Clr |   False | 1.764 ns | 0.0106 ns | 0.0094 ns | 1.760 ns |
|   Foo2 |  Clr |     Clr |   False | 1.175 ns | 0.0235 ns | 0.0305 ns | 1.185 ns |
|   Foo3 |  Clr |     Clr |   False | 1.165 ns | 0.0227 ns | 0.0347 ns | 1.180 ns |
|    Bar |  Clr |     Clr |   False | 1.957 ns | 0.0350 ns | 0.0293 ns | 1.940 ns |
|   Bar2 |  Clr |     Clr |   False | 1.197 ns | 0.0313 ns | 0.0348 ns | 1.190 ns |
|   Bar3 |  Clr |     Clr |   False | 1.165 ns | 0.0156 ns | 0.0146 ns | 1.170 ns |
|    Foo | Core |    Core |   False | 2.142 ns | 0.0237 ns | 0.0185 ns | 2.135 ns |
|   Foo2 | Core |    Core |   False | 1.172 ns | 0.0232 ns | 0.0524 ns | 1.170 ns |
|   Foo3 | Core |    Core |   False | 1.168 ns | 0.0221 ns | 0.0237 ns | 1.170 ns |
|    Bar | Core |    Core |   False | 2.063 ns | 0.0414 ns | 0.0580 ns | 2.040 ns |
|   Bar2 | Core |    Core |   False | 1.169 ns | 0.0235 ns | 0.0392 ns | 1.170 ns |
|   Bar3 | Core |    Core |   False | 1.151 ns | 0.0230 ns | 0.0379 ns | 1.150 ns |
|        |      |         |         |          |           |           |          |
|    Foo |  Clr |     Clr |    True | 1.767 ns | 0.0174 ns | 0.0154 ns | 1.760 ns |
|   Foo2 |  Clr |     Clr |    True | 1.791 ns | 0.0150 ns | 0.0141 ns | 1.790 ns |
|   Foo3 |  Clr |     Clr |    True | 1.784 ns | 0.0196 ns | 0.0174 ns | 1.780 ns |
|    Bar |  Clr |     Clr |    True | 1.767 ns | 0.0075 ns | 0.0063 ns | 1.770 ns |
|   Bar2 |  Clr |     Clr |    True | 1.784 ns | 0.0086 ns | 0.0067 ns | 1.780 ns |
|   Bar3 |  Clr |     Clr |    True | 1.775 ns | 0.0211 ns | 0.0176 ns | 1.780 ns |
|    Foo | Core |    Core |    True | 2.360 ns | 0.0650 ns | 0.1400 ns | 2.290 ns |
|   Foo2 | Core |    Core |    True | 2.553 ns | 0.0987 ns | 0.1754 ns | 2.450 ns |
|   Foo3 | Core |    Core |    True | 2.464 ns | 0.0649 ns | 0.1894 ns | 2.345 ns |
|    Bar | Core |    Core |    True | 1.697 ns | 0.0234 ns | 0.0183 ns | 1.690 ns |
|   Bar2 | Core |    Core |    True | 1.717 ns | 0.0349 ns | 0.0621 ns | 1.695 ns |
|   Bar3 | Core |    Core |    True | 1.647 ns | 0.0223 ns | 0.0198 ns | 1.640 ns |
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
    public void Foo3()
    {
        for (int i = 0; i < blabs.Length; i++) _ = blabs[i].Foo3;
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
    [Benchmark(OperationsPerInvoke = OperationsPerInvoke)]
    public void Bar3()
    {
        for (int i = 0; i < blabs.Length; i++) _ = blabs[i].Bar3;
    }
}
public class Fubar { }
public class Blab
{
    static readonly List<Fubar> s_SharedList = new List<Fubar>();
    public void Reset()
    {
        _foo = _foo2 = _foo3 = null;
        _bar = _bar2 = _bar3 = null;
    }
    private List<Fubar> _foo, _foo2, _foo3;
    private string _bar, _bar2, _bar3;
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
    public List<Fubar> Foo3
    {
        get => _foo3 ?? (_foo3 = s_SharedList);
        set { _foo3 = value; }
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
    public string Bar3
    {
        get => _bar3 ?? (_bar3 = string.Empty);
        set { _bar3 = value; }
    }
}

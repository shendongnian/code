using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
namespace Measure
{
    public static class Program
    {
        static void Main(string[] args) => BenchmarkRunner.Run(typeof(Program).Assembly);
    }
    public class Bench
    {
        [Params("true", "false", "invalid")] public string Input { get; set; }
        [Benchmark]
        public bool IsBoolWithVariable() => bool.TryParse(Input, out var result);
        [Benchmark]
        public bool IsBoolDiscarding() => bool.TryParse(Input, out _);
    }
}
Here's the results:
|             Method |   Input |      Mean |     Error |    StdDev |
|------------------- |-------- |----------:|----------:|----------:|
| IsBoolWithVariable |   false |  7.483 ns | 0.0069 ns | 0.0058 ns |
|   IsBoolDiscarding |   false |  7.479 ns | 0.0040 ns | 0.0034 ns |
| IsBoolWithVariable | invalid | 15.802 ns | 0.0051 ns | 0.0043 ns |
|   IsBoolDiscarding | invalid | 15.838 ns | 0.0043 ns | 0.0038 ns |
| IsBoolWithVariable |    true |  7.055 ns | 0.0053 ns | 0.0047 ns |
|   IsBoolDiscarding |    true |  7.104 ns | 0.0407 ns | 0.0381 ns |
Looks like there's no difference. Let's see if it compiles to the same IL:
`IsBoolDiscarding()`:
    IL_0000: ldarg.0      // this
    IL_0001: call         instance string Measure.Bench::get_Input()
    IL_0006: ldloca.s     V_0
    IL_0008: call         bool [System.Runtime]System.Boolean::TryParse(string, bool&)
    IL_000d: ret
`IsBoolWithVariable()`:
    IL_0000: ldarg.0      // this
    IL_0001: call         instance string Measure.Bench::get_Input()
    IL_0006: ldloca.s     result
    IL_0008: call         bool [System.Runtime]System.Boolean::TryParse(string, bool&)
    IL_000d: ret
So, there is no difference whatsoever.

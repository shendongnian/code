using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
namespace DIMtest
{
    interface IBar {
        int Foo(int i) => i;
    }
    struct Baz : IBar {
        //Does this box?        
        public int  Test2(int i) => ((IBar)this).Foo(i);
    }
    [MemoryDiagnoser, CoreJob,MarkdownExporter]
    public class Program
    {
        public static void Main() => BenchmarkRunner.Run<Program>();
        [Benchmark]
        public int ViaExplicitCast()
        {
            int sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                sum += (new Baz().Test2(i));
            }
            return sum;
        }
    }
}
The results don't show any allocations :
BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18956
Intel Core i7-3770 CPU 3.40GHz (Ivy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview9-014004
  [Host] : .NET Core 3.0.0-preview9-19423-09 (CoreCLR 4.700.19.42102, CoreFX 4.700.19.42104), 64bit RyuJIT
  Core   : .NET Core 3.0.0-preview9-19423-09 (CoreCLR 4.700.19.42102, CoreFX 4.700.19.42104), 64bit RyuJIT
Job=Core  Runtime=Core  
|          Method |     Mean |    Error |   StdDev |   Median | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |---------:|---------:|---------:|---------:|------:|------:|------:|----------:|
| ViaExplicitCast | 629.2 ns | 12.43 ns | 23.65 ns | 619.7 ns |     - |     - |     - |         - |
I changed the return type to an int just like the linked answer to ensure the method won't be optimized away

c#
using BenchmarkDotNet.Attributes;
namespace SO58016813
{
	public static class Program
	{
		public static void Main()
		{
			BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarks>();
		}
	}
	[ClrJob()]
	[CoreJob()]
	public class Benchmarks
	{
		private const int LoopLimit = int.MaxValue;
		[Benchmark(Baseline = true)]
		public void IteratorLessThanConstant()
		{
			for (var i = 0; i < LoopLimit; i++)
			{
				// Do nothing...
			}
		}
		[Benchmark()]
		public void ConstantGreaterThanIterator()
		{
			for (var i = 0; LoopLimit > i; i++)
			{
				// Do nothing...
			}
		}
		[Benchmark()]
		public void IteratorLessThanVariable()
		{
			var loopLimit = LoopLimit;
			for (var i = 0; i < loopLimit; i++)
			{
				// Do nothing...
			}
		}
		[Benchmark()]
		public void VariableGreaterThanIterator()
		{
			var loopLimit = LoopLimit;
			for (var i = 0; loopLimit > i; i++)
			{
				// Do nothing...
			}
		}
	}
}
I did a little research beforehand to ensure that empty loops don't get optimized away and, according to [Is there a way to get the .Net JIT or C# compiler to optimize away empty for-loops?](https://stackoverflow.com/q/7288428/150605), they don't.  Here are the results I got on .NET Framework and .NET Core...
// * Summary *
BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7 CPU 860 2.80GHz (Nehalem), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.802
  [Host] : .NET Core 2.1.13 (CoreCLR 4.6.28008.01, CoreFX 4.6.28008.01), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.8.4010.0
  Core   : .NET Core 2.1.13 (CoreCLR 4.6.28008.01, CoreFX 4.6.28008.01), 64bit RyuJIT
|                      Method |  Job | Runtime |    Mean |    Error |   StdDev | Ratio |
|---------------------------- |----- |-------- |--------:|---------:|---------:|------:|
|    IteratorLessThanConstant |  Clr |     Clr | 1.279 s | 0.0035 s | 0.0031 s |  1.00 |
| ConstantGreaterThanIterator |  Clr |     Clr | 1.279 s | 0.0031 s | 0.0029 s |  1.00 |
|    IteratorLessThanVariable |  Clr |     Clr | 1.288 s | 0.0121 s | 0.0108 s |  1.01 |
| VariableGreaterThanIterator |  Clr |     Clr | 1.280 s | 0.0025 s | 0.0022 s |  1.00 |
|                             |      |         |         |          |          |       |
|    IteratorLessThanConstant | Core |    Core | 1.287 s | 0.0087 s | 0.0081 s |  1.00 |
| ConstantGreaterThanIterator | Core |    Core | 1.278 s | 0.0016 s | 0.0013 s |  0.99 |
|    IteratorLessThanVariable | Core |    Core | 1.280 s | 0.0058 s | 0.0055 s |  0.99 |
| VariableGreaterThanIterator | Core |    Core | 1.279 s | 0.0028 s | 0.0024 s |  0.99 |
// * Hints *
Outliers
  Benchmarks.IteratorLessThanConstant: Clr     -> 1 outlier  was  removed (1.29 s)
  Benchmarks.IteratorLessThanVariable: Clr     -> 1 outlier  was  removed (1.47 s)
  Benchmarks.ConstantGreaterThanIterator: Core -> 2 outliers were removed (1.28 s, 1.29 s)
  Benchmarks.VariableGreaterThanIterator: Core -> 2 outliers were removed (1.29 s, 1.29 s)
Based on the above results...
 - If you're asking if one operator is faster than the other, then I would say no.
 - If you're asking which operator you should use, I would suggest whichever one you feel gives the greatest readability and clarity to your code since that is much more important than any microoptimization, if one even exists.

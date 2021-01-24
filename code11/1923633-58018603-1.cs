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
	[CategoriesColumn()]
	[GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByCategory)]
	public class Benchmarks
	{
		private const int LoopLimit = int.MaxValue;
		[Benchmark(Baseline = true)]
		[BenchmarkCategory("Constant operand")]
		public void IteratorLessThanConstant()
		{
			for (var i = 0; i < LoopLimit; i++)
			{
				// Do nothing...
			}
		}
		[Benchmark()]
		[BenchmarkCategory("Constant operand")]
		public void ConstantGreaterThanIterator()
		{
			for (var i = 0; LoopLimit > i; i++)
			{
				// Do nothing...
			}
		}
		[Benchmark(Baseline = true)]
		[BenchmarkCategory("Variable operand")]
		public void IteratorLessThanVariable()
		{
			var loopLimit = LoopLimit;
			for (var i = 0; i < loopLimit; i++)
			{
				// Do nothing...
			}
		}
		[Benchmark()]
		[BenchmarkCategory("Variable operand")]
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
|                      Method |  Job | Runtime |       Categories |    Mean |    Error |   StdDev | Ratio |
|---------------------------- |----- |-------- |----------------- |--------:|---------:|---------:|------:|
|    IteratorLessThanConstant |  Clr |     Clr | Constant operand | 1.285 s | 0.0063 s | 0.0059 s |  1.00 |
| ConstantGreaterThanIterator |  Clr |     Clr | Constant operand | 1.282 s | 0.0021 s | 0.0020 s |  1.00 |
|                             |      |         |                  |         |          |          |       |
|    IteratorLessThanVariable |  Clr |     Clr | Variable operand | 1.288 s | 0.0065 s | 0.0061 s |  1.00 |
| VariableGreaterThanIterator |  Clr |     Clr | Variable operand | 1.282 s | 0.0028 s | 0.0026 s |  1.00 |
|                             |      |         |                  |         |          |          |       |
|    IteratorLessThanConstant | Core |    Core | Constant operand | 1.286 s | 0.0082 s | 0.0077 s |  1.00 |
| ConstantGreaterThanIterator | Core |    Core | Constant operand | 1.287 s | 0.0072 s | 0.0067 s |  1.00 |
|                             |      |         |                  |         |          |          |       |
|    IteratorLessThanVariable | Core |    Core | Variable operand | 1.284 s | 0.0063 s | 0.0059 s |  1.00 |
| VariableGreaterThanIterator | Core |    Core | Variable operand | 1.286 s | 0.0075 s | 0.0071 s |  1.00 |
Based on the above results...
 - If you're asking if one operator is faster than the other, then I would say no.
 - If you're asking which operator you should use, I would suggest whichever one you feel gives the greatest readability and clarity to your code since that is much more important than any microoptimization, if one even exists.

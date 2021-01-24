c#
public static class DateExtensions
{
	public static string GetUrlDate(this DateTime date)
	{
		return date.GetUrlDate("-");
	}
	public static string GetUrlDate(this DateTime date, string delimiter)
	{
		return DateHelper.GetUrlDate(date, delimiter);
	}
}
...to this...
c#
public static class DateExtensions
{
	public static string GetUrlDate(this DateTime date)
	{
		return DateHelper.GetUrlDate(date, "-");
	}
	public static string GetUrlDate(this DateTime date, string delimiter)
	{
		return DateHelper.GetUrlDate(date, delimiter);
	}
}
...so instead of one overload calling another they both are calling `DateHelper.GetUrlDate(DateTime, String)` directly.  Before you go unwrapping your wrapper methods, though, consider this [BenchmarkDotNet](https://benchmarkdotnet.org/) benchmark...
c#
using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
namespace SO59976711
{
	public static class DateExtensions
	{
		public static string GetUrlDate(this DateTime date)
		{
			return date.GetUrlDate("-");
		}
		public static string GetUrlDate(this DateTime date, string delimiter)
		{
			return DateHelper.GetUrlDate(date, delimiter);
		}
	}
	public static class DateHelper
	{
		public static string GetUrlDate(DateTime date, string delimiter)
		{
			return string.Format("{0:yyyy}{1}{0:MM}{1}{0:dd}", date, delimiter);
		}
	}
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	public class DateFormattingBenchmarks
	{
		private static readonly DateTime TestDate = DateTime.Today;
		private const string TestDelimiter = "-";
		[Benchmark(Baseline = true)]
		public string String_Format()
		{
			// Use the same implementation as DateHelper.GetUrlDate() as a baseline
			return string.Format("{0:yyyy}{1}{0:MM}{1}{0:dd}", TestDate, TestDelimiter);
		}
		[Benchmark()]
		public string DateExtensions_GetUrlDate_DefaultDelimiter()
		{
			return TestDate.GetUrlDate();
		}
		[Benchmark()]
		public string DateExtensions_GetUrlDate_CustomDelimiter()
		{
			return TestDate.GetUrlDate(TestDelimiter);
		}
		[Benchmark()]
		public string DateHelper_GetUrlDate()
		{
			return DateHelper.GetUrlDate(TestDate, TestDelimiter);
		}
	}
	public static class Program
	{
		public static void Main()
		{
			BenchmarkDotNet.Running.BenchmarkRunner.Run<DateFormattingBenchmarks>();
		}
	}
}
...which yields these results...
// * Summary *
BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18363
Intel Core i7 CPU 860 2.80GHz (Nehalem), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.101
  [Host]     : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT
  Job-RTUGNF : .NET Framework 4.8 (4.8.4075.0), X64 RyuJIT
  Job-NPEBBX : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT
|                                     Method |       Runtime |       Mean |   Error |  StdDev | Ratio |
|------------------------------------------- |-------------- |-----------:|--------:|--------:|------:|
|                              String_Format |      .NET 4.8 | 1,044.6 ns | 6.71 ns | 5.60 ns |  1.00 |
| DateExtensions_GetUrlDate_DefaultDelimiter |      .NET 4.8 | 1,040.0 ns | 4.55 ns | 4.26 ns |  1.00 |
|  DateExtensions_GetUrlDate_CustomDelimiter |      .NET 4.8 | 1,045.6 ns | 8.31 ns | 6.49 ns |  1.00 |
|                      DateHelper_GetUrlDate |      .NET 4.8 | 1,045.0 ns | 6.18 ns | 5.47 ns |  1.00 |
|                                            |               |            |         |         |       |
|                              String_Format | .NET Core 3.1 |   623.7 ns | 4.92 ns | 4.36 ns |  1.00 |
| DateExtensions_GetUrlDate_DefaultDelimiter | .NET Core 3.1 |   624.9 ns | 2.89 ns | 2.71 ns |  1.00 |
|  DateExtensions_GetUrlDate_CustomDelimiter | .NET Core 3.1 |   618.5 ns | 2.48 ns | 2.07 ns |  0.99 |
|                      DateHelper_GetUrlDate | .NET Core 3.1 |   621.4 ns | 2.97 ns | 2.48 ns |  1.00 |
As you can see, there is **no performance difference** between calling any of your three helper methods and `string.Format()` itself.  This means you should implement your methods in whatever way is the most maintainable with the least redundancy (i.e. keep them the way they are) because there are no gains to be had by duplicating code or "pre-inlining" inlinable methods.

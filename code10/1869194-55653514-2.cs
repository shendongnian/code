csharp
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
namespace ConsoleApp
{
    public static class EnumerableExtensions
    {
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }
    }
    public static class Program
    {
        [ClrJob]
        [RPlotExporter, RankColumn]
        public class Paralleling
        {
            private IEnumerable<int> _items;
            [GlobalSetup]
            public void Setup()
            {
                _items = Enumerable.Range(0, 5000);
            }
            private bool GetMeALongCpuBool(int number)
            {
                Thread.Sleep(10);
                return number % 2 == 0;
            }
            [Benchmark]
            public async Task DataFlow()
            {
                var transformBlock = new TransformBlock<int, (bool, int, int)>(item =>
                {
                    var dummy = GetMeALongCpuBool(item);
                    return (dummy, item, Thread.CurrentThread.ManagedThreadId);
                }, new ExecutionDataflowBlockOptions
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount
                });
                using (var streamWriter = new StreamWriter(new MemoryStream()))
                {
                    var actionBlock = new ActionBlock<(bool, int, int)>(async result =>
                    await streamWriter.WriteLineAsync(result.ToString()));
                    transformBlock.LinkTo(actionBlock, new ExecutionDataflowBlockOptions
                    {
                        PropagateCompletion = true
                    });
                    _items.ForEach(async item => await transformBlock.SendAsync(item));
                    transformBlock.Complete();
                    await actionBlock.Completion;
                }
            }
            [Benchmark]
            public async Task ParallelAndSequential()
            {
                var blockingCollection = new BlockingCollection<(bool, int, int)>();
                Task.Run(() =>
                {
                    Parallel.ForEach(_items, item =>
                    {
                        var dummy = GetMeALongCpuBool(item);
                        blockingCollection.Add((dummy, item, Thread.CurrentThread.ManagedThreadId));
                    });
                    blockingCollection.CompleteAdding();
                });
                using (var streamWriter = new StreamWriter(new MemoryStream()))
                {
                    foreach (var result in blockingCollection.GetConsumingEnumerable())
                    {
                        await streamWriter.WriteLineAsync(result.ToString());
                    }
                }
            }
            [Benchmark]
            public async Task AllSequential()
            {
                using (var streamWriter = new StreamWriter(new MemoryStream()))
                {
                    foreach (var item in _items)
                    {
                        var dummy = GetMeALongCpuBool(item);
                        var result = (dummy, item, Thread.CurrentThread.ManagedThreadId);
                        await streamWriter.WriteLineAsync(result.ToString());
                    }
                }
            }
        }
        public static void Main(params string[] args)
        {
            var summary = BenchmarkRunner.Run<Paralleling>();
        }
    }
}
For some reasons it seems that this time the `Parallel.ForEach` is the fastest option followed by the Dataflow(maybe the actor system behind the scenes added some overhead but it provides a smoother integration with `async`/`await`) which seems to be still a little bit more aggressive than just using `BlockingCollection.GetConsumingEnumerable` which posses a relatively simple [implementation](https://github.com/Microsoft/referencesource/blob/master/System/sys/system/collections/concurrent/BlockingCollection.cs#L1670).
In both cases (`Parallel.ForEach` and Dataflow), (they) are still much faster than the plain sequential old way, which is what I was expecting initially.
New benchmark results are right below:
// Validating benchmarks:
// ***** BenchmarkRunner: Start   *****
// ***** Found 3 benchmark(s) in total *****
// ***** Building 1 exe(s) in Parallel: Start   *****
BuildScript: C:\Users\eperret\Desktop\Playground\ConsoleApp\ConsoleApp\ConsoleApp\bin\Release\net472\34fab948-1750-4a20-832f-c235d6c6b967.bat
// ***** Done, took 00:00:03 (3.47 sec)   *****
// Found 3 benchmarks:
//   Paralleling.DataFlow: Clr(Runtime=Clr)
//   Paralleling.ParallelAndSequential: Clr(Runtime=Clr)
//   Paralleling.AllSequential: Clr(Runtime=Clr)
Setup power plan (GUID: 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c FriendlyName: High performance)// **************************
// Benchmark: Paralleling.DataFlow: Clr(Runtime=Clr)
// *** Execute ***
// Launch: 1 / 1
// Execute: C:\Users\eperret\Desktop\Playground\ConsoleApp\ConsoleApp\ConsoleApp\bin\Release\net472\34fab948-1750-4a20-832f-c235d6c6b967.exe --b
enchmarkName "ConsoleApp.Program+Paralleling.DataFlow" --job "Clr" --benchmarkId 0 in 
// BeforeAnythingElse
// Benchmark Process Environment Information:
// Runtime=.NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3221.0
// GC=Concurrent Workstation
// Job: Clr(Runtime=Clr)
OverheadJitting  1: 1 op, 301500.00 ns, 301.5000 us/op
WorkloadJitting  1: 1 op, 6766114100.00 ns, 6.7661 s/op
WorkloadWarmup   1: 1 op, 6684374600.00 ns, 6.6844 s/op
WorkloadWarmup   2: 1 op, 6741597000.00 ns, 6.7416 s/op
WorkloadWarmup   3: 1 op, 6678205800.00 ns, 6.6782 s/op
WorkloadWarmup   4: 1 op, 6694086900.00 ns, 6.6941 s/op
WorkloadWarmup   5: 1 op, 6725310100.00 ns, 6.7253 s/op
WorkloadWarmup   6: 1 op, 6739073300.00 ns, 6.7391 s/op
WorkloadWarmup   7: 1 op, 6701728400.00 ns, 6.7017 s/op
// BeforeActualRun
WorkloadActual   1: 1 op, 6739354900.00 ns, 6.7394 s/op
WorkloadActual   2: 1 op, 6705538000.00 ns, 6.7055 s/op
WorkloadActual   3: 1 op, 6705645700.00 ns, 6.7056 s/op
WorkloadActual   4: 1 op, 6734594900.00 ns, 6.7346 s/op
WorkloadActual   5: 1 op, 6687179600.00 ns, 6.6872 s/op
WorkloadActual   6: 1 op, 6681016900.00 ns, 6.6810 s/op
WorkloadActual   7: 1 op, 6708053800.00 ns, 6.7081 s/op
WorkloadActual   8: 1 op, 6703350900.00 ns, 6.7034 s/op
WorkloadActual   9: 1 op, 6709533800.00 ns, 6.7095 s/op
WorkloadActual  10: 1 op, 6742676000.00 ns, 6.7427 s/op
WorkloadActual  11: 1 op, 6710231600.00 ns, 6.7102 s/op
WorkloadActual  12: 1 op, 6695547000.00 ns, 6.6955 s/op
WorkloadActual  13: 1 op, 6708751300.00 ns, 6.7088 s/op
WorkloadActual  14: 1 op, 6731132100.00 ns, 6.7311 s/op
WorkloadActual  15: 1 op, 6828591700.00 ns, 6.8286 s/op
// AfterActualRun
WorkloadResult   1: 1 op, 6739354900.00 ns, 6.7394 s/op
WorkloadResult   2: 1 op, 6705538000.00 ns, 6.7055 s/op
WorkloadResult   3: 1 op, 6705645700.00 ns, 6.7056 s/op
WorkloadResult   4: 1 op, 6734594900.00 ns, 6.7346 s/op
WorkloadResult   5: 1 op, 6687179600.00 ns, 6.6872 s/op
WorkloadResult   6: 1 op, 6681016900.00 ns, 6.6810 s/op
WorkloadResult   7: 1 op, 6708053800.00 ns, 6.7081 s/op
WorkloadResult   8: 1 op, 6703350900.00 ns, 6.7034 s/op
WorkloadResult   9: 1 op, 6709533800.00 ns, 6.7095 s/op
WorkloadResult  10: 1 op, 6742676000.00 ns, 6.7427 s/op
WorkloadResult  11: 1 op, 6710231600.00 ns, 6.7102 s/op
WorkloadResult  12: 1 op, 6695547000.00 ns, 6.6955 s/op
WorkloadResult  13: 1 op, 6708751300.00 ns, 6.7088 s/op
WorkloadResult  14: 1 op, 6731132100.00 ns, 6.7311 s/op
GC:  0 0 0 0 0
// AfterAll
Mean = 6.7116 s, StdErr = 0.0050 s (0.07%); N = 14, StdDev = 0.0188 s
Min = 6.6810 s, Q1 = 6.7034 s, Median = 6.7084 s, Q3 = 6.7311 s, Max = 6.7427 s
IQR = 0.0278 s, LowerFence = 6.6617 s, UpperFence = 6.7728 s
ConfidenceInterval = [6.6904 s; 6.7328 s] (CI 99.9%), Margin = 0.0212 s (0.32% of Mean)
Skewness = 0.24, Kurtosis = 1.85, MValue = 2
// **************************
// Benchmark: Paralleling.ParallelAndSequential: Clr(Runtime=Clr)
// *** Execute ***
// Launch: 1 / 1
// Execute: C:\Users\eperret\Desktop\Playground\ConsoleApp\ConsoleApp\ConsoleApp\bin\Release\net472\34fab948-1750-4a20-832f-c235d6c6b967.exe --b
enchmarkName "ConsoleApp.Program+Paralleling.ParallelAndSequential" --job "Clr" --benchmarkId 1 in 
// BeforeAnythingElse
// Benchmark Process Environment Information:
// Runtime=.NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3221.0
// GC=Concurrent Workstation
// Job: Clr(Runtime=Clr)
OverheadJitting  1: 1 op, 374800.00 ns, 374.8000 us/op
WorkloadJitting  1: 1 op, 6956299700.00 ns, 6.9563 s/op
WorkloadWarmup   1: 1 op, 6046076100.00 ns, 6.0461 s/op
WorkloadWarmup   2: 1 op, 6852625900.00 ns, 6.8526 s/op
WorkloadWarmup   3: 1 op, 5474965800.00 ns, 5.4750 s/op
WorkloadWarmup   4: 1 op, 5473499200.00 ns, 5.4735 s/op
WorkloadWarmup   5: 1 op, 5518366900.00 ns, 5.5184 s/op
WorkloadWarmup   6: 1 op, 6859923700.00 ns, 6.8599 s/op
WorkloadWarmup   7: 1 op, 6862675600.00 ns, 6.8627 s/op
WorkloadWarmup   8: 1 op, 5536335800.00 ns, 5.5363 s/op
// BeforeActualRun
WorkloadActual   1: 1 op, 5528208700.00 ns, 5.5282 s/op
WorkloadActual   2: 1 op, 5519601400.00 ns, 5.5196 s/op
WorkloadActual   3: 1 op, 5500471200.00 ns, 5.5005 s/op
WorkloadActual   4: 1 op, 5539328200.00 ns, 5.5393 s/op
WorkloadActual   5: 1 op, 5465452200.00 ns, 5.4655 s/op
WorkloadActual   6: 1 op, 5470452100.00 ns, 5.4705 s/op
WorkloadActual   7: 1 op, 5512168300.00 ns, 5.5122 s/op
WorkloadActual   8: 1 op, 5472912400.00 ns, 5.4729 s/op
WorkloadActual   9: 1 op, 5855563000.00 ns, 5.8556 s/op
WorkloadActual  10: 1 op, 5992147700.00 ns, 5.9921 s/op
WorkloadActual  11: 1 op, 6143075000.00 ns, 6.1431 s/op
WorkloadActual  12: 1 op, 6397675600.00 ns, 6.3977 s/op
WorkloadActual  13: 1 op, 6909029100.00 ns, 6.9090 s/op
WorkloadActual  14: 1 op, 5525335600.00 ns, 5.5253 s/op
WorkloadActual  15: 1 op, 5470029700.00 ns, 5.4700 s/op
WorkloadActual  16: 1 op, 5481800300.00 ns, 5.4818 s/op
WorkloadActual  17: 1 op, 5507468600.00 ns, 5.5075 s/op
WorkloadActual  18: 1 op, 5465031900.00 ns, 5.4650 s/op
WorkloadActual  19: 1 op, 5478785200.00 ns, 5.4788 s/op
WorkloadActual  20: 1 op, 5511074600.00 ns, 5.5111 s/op
WorkloadActual  21: 1 op, 6080651400.00 ns, 6.0807 s/op
WorkloadActual  22: 1 op, 6829810900.00 ns, 6.8298 s/op
WorkloadActual  23: 1 op, 6878471900.00 ns, 6.8785 s/op
WorkloadActual  24: 1 op, 5506067800.00 ns, 5.5061 s/op
WorkloadActual  25: 1 op, 5442596200.00 ns, 5.4426 s/op
WorkloadActual  26: 1 op, 5463614300.00 ns, 5.4636 s/op
WorkloadActual  27: 1 op, 5491205500.00 ns, 5.4912 s/op
WorkloadActual  28: 1 op, 5482997900.00 ns, 5.4830 s/op
WorkloadActual  29: 1 op, 5494967800.00 ns, 5.4950 s/op
WorkloadActual  30: 1 op, 5517805900.00 ns, 5.5178 s/op
WorkloadActual  31: 1 op, 5486377000.00 ns, 5.4864 s/op
// AfterActualRun
WorkloadResult   1: 1 op, 5528208700.00 ns, 5.5282 s/op
WorkloadResult   2: 1 op, 5519601400.00 ns, 5.5196 s/op
WorkloadResult   3: 1 op, 5500471200.00 ns, 5.5005 s/op
WorkloadResult   4: 1 op, 5539328200.00 ns, 5.5393 s/op
WorkloadResult   5: 1 op, 5465452200.00 ns, 5.4655 s/op
WorkloadResult   6: 1 op, 5470452100.00 ns, 5.4705 s/op
WorkloadResult   7: 1 op, 5512168300.00 ns, 5.5122 s/op
WorkloadResult   8: 1 op, 5472912400.00 ns, 5.4729 s/op
WorkloadResult   9: 1 op, 5855563000.00 ns, 5.8556 s/op
WorkloadResult  10: 1 op, 5992147700.00 ns, 5.9921 s/op
WorkloadResult  11: 1 op, 6143075000.00 ns, 6.1431 s/op
WorkloadResult  12: 1 op, 6397675600.00 ns, 6.3977 s/op
WorkloadResult  13: 1 op, 5525335600.00 ns, 5.5253 s/op
WorkloadResult  14: 1 op, 5470029700.00 ns, 5.4700 s/op
WorkloadResult  15: 1 op, 5481800300.00 ns, 5.4818 s/op
WorkloadResult  16: 1 op, 5507468600.00 ns, 5.5075 s/op
WorkloadResult  17: 1 op, 5465031900.00 ns, 5.4650 s/op
WorkloadResult  18: 1 op, 5478785200.00 ns, 5.4788 s/op
WorkloadResult  19: 1 op, 5511074600.00 ns, 5.5111 s/op
WorkloadResult  20: 1 op, 6080651400.00 ns, 6.0807 s/op
WorkloadResult  21: 1 op, 5506067800.00 ns, 5.5061 s/op
WorkloadResult  22: 1 op, 5442596200.00 ns, 5.4426 s/op
WorkloadResult  23: 1 op, 5463614300.00 ns, 5.4636 s/op
WorkloadResult  24: 1 op, 5491205500.00 ns, 5.4912 s/op
WorkloadResult  25: 1 op, 5482997900.00 ns, 5.4830 s/op
WorkloadResult  26: 1 op, 5494967800.00 ns, 5.4950 s/op
WorkloadResult  27: 1 op, 5517805900.00 ns, 5.5178 s/op
WorkloadResult  28: 1 op, 5486377000.00 ns, 5.4864 s/op
GC:  0 0 0 0 0
// AfterAll
Mean = 5.6001 s, StdErr = 0.0469 s (0.84%); N = 28, StdDev = 0.2479 s
Min = 5.4426 s, Q1 = 5.4758 s, Median = 5.5033 s, Q3 = 5.5268 s, Max = 6.3977 s
IQR = 0.0509 s, LowerFence = 5.3995 s, UpperFence = 5.6032 s
ConfidenceInterval = [5.4272 s; 5.7730 s] (CI 99.9%), Margin = 0.1729 s (3.09% of Mean)
Skewness = 1.93, Kurtosis = 5.45, MValue = 2
// **************************
// Benchmark: Paralleling.AllSequential: Clr(Runtime=Clr)
// *** Execute ***
// Launch: 1 / 1
// Execute: C:\Users\eperret\Desktop\Playground\ConsoleApp\ConsoleApp\ConsoleApp\bin\Release\net472\34fab948-1750-4a20-832f-c235d6c6b967.exe -
-benchmarkName "ConsoleApp.Program+Paralleling.AllSequential" --job "Clr" --benchmarkId 2 in 
// BeforeAnythingElse
// Benchmark Process Environment Information:
// Runtime=.NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3221.0
// GC=Concurrent Workstation
// Job: Clr(Runtime=Clr)
OverheadJitting  1: 1 op, 293200.00 ns, 293.2000 us/op
WorkloadJitting  1: 1 op, 53809888100.00 ns, 53.8099 s/op
WorkloadWarmup   1: 1 op, 53587422400.00 ns, 53.5874 s/op
WorkloadWarmup   2: 1 op, 53646293300.00 ns, 53.6463 s/op
WorkloadWarmup   3: 1 op, 53664071000.00 ns, 53.6641 s/op
WorkloadWarmup   4: 1 op, 53565564100.00 ns, 53.5656 s/op
WorkloadWarmup   5: 1 op, 53753653900.00 ns, 53.7537 s/op
WorkloadWarmup   6: 1 op, 53765022400.00 ns, 53.7650 s/op
WorkloadWarmup   7: 1 op, 53548369900.00 ns, 53.5484 s/op
// BeforeActualRun
WorkloadActual   1: 1 op, 53571559600.00 ns, 53.5716 s/op
WorkloadActual   2: 1 op, 53777716600.00 ns, 53.7777 s/op
WorkloadActual   3: 1 op, 53634262000.00 ns, 53.6343 s/op
WorkloadActual   4: 1 op, 53555998800.00 ns, 53.5560 s/op
WorkloadActual   5: 1 op, 53529152600.00 ns, 53.5292 s/op
WorkloadActual   6: 1 op, 53609217000.00 ns, 53.6092 s/op
WorkloadActual   7: 1 op, 53511316400.00 ns, 53.5113 s/op
WorkloadActual   8: 1 op, 53246673500.00 ns, 53.2467 s/op
WorkloadActual   9: 1 op, 53770915500.00 ns, 53.7709 s/op
WorkloadActual  10: 1 op, 54462781200.00 ns, 54.4628 s/op
WorkloadActual  11: 1 op, 54111001500.00 ns, 54.1110 s/op
WorkloadActual  12: 1 op, 54194051600.00 ns, 54.1941 s/op
WorkloadActual  13: 1 op, 53924013600.00 ns, 53.9240 s/op
WorkloadActual  14: 1 op, 53855213500.00 ns, 53.8552 s/op
WorkloadActual  15: 1 op, 53919584800.00 ns, 53.9196 s/op
// AfterActualRun
WorkloadResult   1: 1 op, 53571559600.00 ns, 53.5716 s/op
WorkloadResult   2: 1 op, 53777716600.00 ns, 53.7777 s/op
WorkloadResult   3: 1 op, 53634262000.00 ns, 53.6343 s/op
WorkloadResult   4: 1 op, 53555998800.00 ns, 53.5560 s/op
WorkloadResult   5: 1 op, 53529152600.00 ns, 53.5292 s/op
WorkloadResult   6: 1 op, 53609217000.00 ns, 53.6092 s/op
WorkloadResult   7: 1 op, 53511316400.00 ns, 53.5113 s/op
WorkloadResult   8: 1 op, 53246673500.00 ns, 53.2467 s/op
WorkloadResult   9: 1 op, 53770915500.00 ns, 53.7709 s/op
WorkloadResult  10: 1 op, 54462781200.00 ns, 54.4628 s/op
WorkloadResult  11: 1 op, 54111001500.00 ns, 54.1110 s/op
WorkloadResult  12: 1 op, 54194051600.00 ns, 54.1941 s/op
WorkloadResult  13: 1 op, 53924013600.00 ns, 53.9240 s/op
WorkloadResult  14: 1 op, 53855213500.00 ns, 53.8552 s/op
WorkloadResult  15: 1 op, 53919584800.00 ns, 53.9196 s/op
GC:  0 0 0 0 0
// AfterAll
Mean = 53.7782 s, StdErr = 0.0804 s (0.15%); N = 15, StdDev = 0.3113 s
Min = 53.2467 s, Q1 = 53.5560 s, Median = 53.7709 s, Q3 = 53.9240 s, Max = 54.4628 s
IQR = 0.3680 s, LowerFence = 53.0040 s, UpperFence = 54.4760 s
ConfidenceInterval = [53.4454 s; 54.1110 s] (CI 99.9%), Margin = 0.3328 s (0.62% of Mean)
Skewness = 0.49, Kurtosis = 2.53, MValue = 2
Successfully reverted power plan (GUID: 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c FriendlyName: High performance)
// ***** BenchmarkRunner: Finish  *****
// * Export *
  BenchmarkDotNet.Artifacts\results\ConsoleApp.Program.Paralleling-report.csv
  BenchmarkDotNet.Artifacts\results\ConsoleApp.Program.Paralleling-report-github.md
  BenchmarkDotNet.Artifacts\results\ConsoleApp.Program.Paralleling-report.html
  BenchmarkDotNet.Artifacts\results\ConsoleApp.Program.Paralleling-measurements.csv
  BuildPlots.R
RPlotExporter couldn't find Rscript.exe in your PATH and no R_HOME environment variable is defined
// * Detailed results *
Paralleling.DataFlow: Clr(Runtime=Clr)
Runtime = .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3221.0; GC = Concurrent Workstation
Mean = 6.7116 s, StdErr = 0.0050 s (0.07%); N = 14, StdDev = 0.0188 s
Min = 6.6810 s, Q1 = 6.7034 s, Median = 6.7084 s, Q3 = 6.7311 s, Max = 6.7427 s
IQR = 0.0278 s, LowerFence = 6.6617 s, UpperFence = 6.7728 s
ConfidenceInterval = [6.6904 s; 6.7328 s] (CI 99.9%), Margin = 0.0212 s (0.32% of Mean)
Skewness = 0.24, Kurtosis = 1.85, MValue = 2
-------------------- Histogram --------------------
[6.674 s ; 6.750 s) | @@@@@@@@@@@@@@
---------------------------------------------------
Paralleling.ParallelAndSequential: Clr(Runtime=Clr)
Runtime = .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3221.0; GC = Concurrent Workstation
Mean = 5.6001 s, StdErr = 0.0469 s (0.84%); N = 28, StdDev = 0.2479 s
Min = 5.4426 s, Q1 = 5.4758 s, Median = 5.5033 s, Q3 = 5.5268 s, Max = 6.3977 s
IQR = 0.0509 s, LowerFence = 5.3995 s, UpperFence = 5.6032 s
ConfidenceInterval = [5.4272 s; 5.7730 s] (CI 99.9%), Margin = 0.1729 s (3.09% of Mean)
Skewness = 1.93, Kurtosis = 5.45, MValue = 2
-------------------- Histogram --------------------
[5.420 s ; 5.562 s) | @@@@@@@@@@@@@@@@@@@@@@@
[5.562 s ; 5.705 s) | 
[5.705 s ; 5.852 s) | 
[5.852 s ; 5.995 s) | @@
[5.995 s ; 6.183 s) | @@
[6.183 s ; 6.326 s) | 
[6.326 s ; 6.469 s) | @
---------------------------------------------------
Paralleling.AllSequential: Clr(Runtime=Clr)
Runtime = .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3221.0; GC = Concurrent Workstation
Mean = 53.7782 s, StdErr = 0.0804 s (0.15%); N = 15, StdDev = 0.3113 s
Min = 53.2467 s, Q1 = 53.5560 s, Median = 53.7709 s, Q3 = 53.9240 s, Max = 54.4628 s
IQR = 0.3680 s, LowerFence = 53.0040 s, UpperFence = 54.4760 s
ConfidenceInterval = [53.4454 s; 54.1110 s] (CI 99.9%), Margin = 0.3328 s (0.62% of Mean)
Skewness = 0.49, Kurtosis = 2.53, MValue = 2
-------------------- Histogram --------------------
[53.136 s ; 54.573 s) | @@@@@@@@@@@@@@@
---------------------------------------------------
// * Summary *
BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.407 (1803/April2018Update/Redstone4)
Intel Core i7-7820HQ CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host] : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3221.0
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3221.0
Job=Clr  Runtime=Clr  
|                Method |     Mean |    Error |   StdDev | Rank |
|---------------------- |---------:|---------:|---------:|-----:|
|              DataFlow |  6.712 s | 0.0212 s | 0.0188 s |    2 |
| ParallelAndSequential |  5.600 s | 0.1729 s | 0.2479 s |    1 |
|         AllSequential | 53.778 s | 0.3328 s | 0.3113 s |    3 |
// * Hints *
Outliers
  Paralleling.DataFlow: Clr              -> 1 outlier  was  removed (6.83 s)
  Paralleling.ParallelAndSequential: Clr -> 3 outliers were removed (6.83 s..6.91 s)
// * Legends *
  Mean   : Arithmetic mean of all measurements
  Error  : Half of 99.9% confidence interval
  StdDev : Standard deviation of all measurements
  Rank   : Relative position of current benchmark mean among all benchmarks (Arabic style)
  1 s    : 1 Second (1 sec)
// ***** BenchmarkRunner: End *****
// ** Remained 0 benchmark(s) to run **
Run time: 00:27:06 (1626.41 sec), executed benchmarks: 3
Global total time: 00:27:09 (1629.9 sec), executed benchmarks: 3
// * Artifacts cleanup *

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    using System;
    
    namespace PerfTest
    {
        [DisassemblyDiagnoser(printAsm: true, printSource: true)]
        public class Test
        {
            private int[] data;
            private int[] data_iteration;
    
            private int Threshold = 50;
            private const int ConstThreshold = 50;
    
            [GlobalSetup]
            public void GlobalSetup()
            {
                data = new int[100000];
                var random = new Random(42);
                for (var i = 0; i < data.Length; i++)
                {
                    data[i] = random.Next(100);
                }
            }
    
            [IterationSetup]
            public void IterationSetup()
            {
                data_iteration = new int[data.Length];
                Array.Copy(data, data_iteration, data.Length);
            }
    
            static void Main(string[] args)
            {
                var summary = BenchmarkRunner.Run<Test>();
            }
    
            [Benchmark]
            public void ClampToClassConstValue()
            {
                for (var i = 0; i < data_iteration.Length; i++)
                {
                    if (data_iteration[i] > ConstThreshold) data_iteration[i] = ConstThreshold;
                }
            }
    
            [Benchmark]
            public void ClampToLocalConstValue()
            {
                const int ConstThresholdLocal = 50;
                for (var i = 0; i < data_iteration.Length; i++)
                {
                    if (data_iteration[i] > ConstThresholdLocal) data_iteration[i] = ConstThresholdLocal;
                }
            }
    
            [Benchmark]
            public void ClampToInlineValue()
            {
                for (var i = 0; i < data_iteration.Length; i++)
                {
                    if (data_iteration[i] > 50) data_iteration[i] = 50;
                }
            }
    
            [Benchmark]
            public void ClampToLocalVariable()
            {
                var ThresholdLocal = 50;
                for (var i = 0; i < data_iteration.Length; i++)
                {
                    if (data_iteration[i] > ThresholdLocal) data_iteration[i] = ThresholdLocal;
                }
            }
    
            [Benchmark(Baseline = true)]
            public void ClampToMemberValue()
            {
                for (var i = 0; i < data_iteration.Length; i++)
                {
                    if (data_iteration[i] > Threshold) data_iteration[i] = Threshold;
                }
            }
        }
    }

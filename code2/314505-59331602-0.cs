    [MemoryDiagnoser, ThreadingDiagnoser]
    [SimpleJob(runtimeMoniker: RuntimeMoniker.NetCoreApp31)]
    [GenericTypeArguments(typeof(TestClass))]
    public class ActivatorBenchmark<T> where T : new()
    {
        [Benchmark(Baseline = true)]
        [Arguments(1_000)]
        [Arguments(1_000_000)]
        [Arguments(100_000_000)]
        public void ActivatorTest1(int x)
        {
            for (int i = 0; i < x; i++)
            {
                var t = new T();
            }
        }
        [Benchmark]
        [Arguments(1_000)]
        [Arguments(1_000_000)]
        [Arguments(100_000_000)]
        public void ActivatorTest2(int x)
        {
            for (int i = 0; i < x; i++)
            {
                var t = New<T>.Instance();
            }
        }
    }
    public class TestClass
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
    }
    public static class TestHelpers
    {
        public static class New<T>
        {
            public static readonly Func<T> Instance = Creator();
            private static Func<T> Creator()
            {
                Type t = typeof(T);
                if (t == typeof(string))
                    return Expression.Lambda<Func<T>>(Expression.Constant(string.Empty)).Compile();
                if (t.HasDefaultConstructor())
                    return Expression.Lambda<Func<T>>(Expression.New(t)).Compile();
                return () => (T)FormatterServices.GetUninitializedObject(t);
            }
        }
        public static bool HasDefaultConstructor(this Type t)
        {
            return t.IsValueType || t.GetConstructor(Type.EmptyTypes) != null;
        }
    }
.
    // * Detailed results *
    ActivatorBenchmark<TestClass>.ActivatorTest1: Job-RRTXQH(Runtime=.NET Core 3.1) [x=1000]
    Runtime = .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT; GC = Concurrent Workstation
    Mean = 30.9925 us, StdErr = 0.1962 us (0.63%); N = 17, StdDev = 0.8088 us
    Min = 30.2190 us, Q1 = 30.4151 us, Median = 30.4745 us, Q3 = 31.5188 us, Max = 32.7203 us
    IQR = 1.1037 us, LowerFence = 28.7595 us, UpperFence = 33.1744 us
    ConfidenceInterval = [30.2049 us; 31.7802 us] (CI 99.9%), Margin = 0.7876 us (2.54% of Mean)
    Skewness = 0.96, Kurtosis = 2.4, MValue = 2
    -------------------- Histogram --------------------
    [29.944 us ; 30.909 us) | @@@@@@@@@@@
    [30.909 us ; 31.555 us) | @@
    [31.555 us ; 32.301 us) | @@
    [32.301 us ; 32.996 us) | @@
    ---------------------------------------------------
    
    ActivatorBenchmark<TestClass>.ActivatorTest2: Job-RRTXQH(Runtime=.NET Core 3.1) [x=1000]
    Runtime = .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT; GC = Concurrent Workstation
    Mean = 7.0534 us, StdErr = 0.0144 us (0.20%); N = 14, StdDev = 0.0538 us
    Min = 6.9228 us, Q1 = 7.0269 us, Median = 7.0687 us, Q3 = 7.0849 us, Max = 7.1367 us
    IQR = 0.0580 us, LowerFence = 6.9399 us, UpperFence = 7.1718 us
    ConfidenceInterval = [6.9927 us; 7.1142 us] (CI 99.9%), Margin = 0.0607 us (0.86% of Mean)
    Skewness = -0.76, Kurtosis = 3.12, MValue = 2
    -------------------- Histogram --------------------
    [6.903 us ; 7.148 us) | @@@@@@@@@@@@@@
    ---------------------------------------------------
    
    ActivatorBenchmark<TestClass>.ActivatorTest1: Job-RRTXQH(Runtime=.NET Core 3.1) [x=1000000]
    Runtime = .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT; GC = Concurrent Workstation
    Mean = 27.6912 ms, StdErr = 0.0412 ms (0.15%); N = 13, StdDev = 0.1486 ms
    Min = 27.5318 ms, Q1 = 27.6171 ms, Median = 27.6435 ms, Q3 = 27.7196 ms, Max = 28.0946 ms
    IQR = 0.1025 ms, LowerFence = 27.4633 ms, UpperFence = 27.8734 ms
    ConfidenceInterval = [27.5132 ms; 27.8691 ms] (CI 99.9%), Margin = 0.1780 ms (0.64% of Mean)
    Skewness = 1.56, Kurtosis = 4.57, MValue = 2
    -------------------- Histogram --------------------
    [27.477 ms ; 28.150 ms) | @@@@@@@@@@@@@
    ---------------------------------------------------
    
    ActivatorBenchmark<TestClass>.ActivatorTest2: Job-RRTXQH(Runtime=.NET Core 3.1) [x=1000000]
    Runtime = .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT; GC = Concurrent Workstation
    Mean = 7.0697 ms, StdErr = 0.0239 ms (0.34%); N = 15, StdDev = 0.0927 ms
    Min = 6.9195 ms, Q1 = 6.9889 ms, Median = 7.0681 ms, Q3 = 7.1187 ms, Max = 7.2497 ms
    IQR = 0.1298 ms, LowerFence = 6.7942 ms, UpperFence = 7.3134 ms
    ConfidenceInterval = [6.9706 ms; 7.1687 ms] (CI 99.9%), Margin = 0.0991 ms (1.40% of Mean)
    Skewness = 0.22, Kurtosis = 2.08, MValue = 2
    -------------------- Histogram --------------------
    [6.887 ms ; 7.252 ms) | @@@@@@@@@@@@@@@
    ---------------------------------------------------
    
    ActivatorBenchmark<TestClass>.ActivatorTest1: Job-RRTXQH(Runtime=.NET Core 3.1) [x=100000000]
    Runtime = .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT; GC = Concurrent Workstation
    Mean = 2.7852 s, StdErr = 0.0093 s (0.33%); N = 15, StdDev = 0.0358 s
    Min = 2.7426 s, Q1 = 2.7576 s, Median = 2.7693 s, Q3 = 2.8141 s, Max = 2.8629 s
    IQR = 0.0565 s, LowerFence = 2.6728 s, UpperFence = 2.8989 s
    ConfidenceInterval = [2.7469 s; 2.8235 s] (CI 99.9%), Margin = 0.0383 s (1.38% of Mean)
    Skewness = 0.76, Kurtosis = 2.21, MValue = 2
    -------------------- Histogram --------------------
    [2.735 s ; 2.796 s) | @@@@@@@@@@
    [2.796 s ; 2.876 s) | @@@@@
    ---------------------------------------------------
    
    ActivatorBenchmark<TestClass>.ActivatorTest2: Job-RRTXQH(Runtime=.NET Core 3.1) [x=100000000]
    Runtime = .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT; GC = Concurrent Workstation
    Mean = 698.4029 ms, StdErr = 1.3760 ms (0.20%); N = 15, StdDev = 5.3292 ms
    Min = 688.2649 ms, Q1 = 693.8483 ms, Median = 697.9546 ms, Q3 = 703.2100 ms, Max = 707.1939 ms
    IQR = 9.3617 ms, LowerFence = 679.8057 ms, UpperFence = 717.2526 ms
    ConfidenceInterval = [692.7056 ms; 704.1001 ms] (CI 99.9%), Margin = 5.6972 ms (0.82% of Mean)
    Skewness = 0.09, Kurtosis = 2.08, MValue = 2
    -------------------- Histogram --------------------
    [686.374 ms ; 709.085 ms) | @@@@@@@@@@@@@@@
    ---------------------------------------------------
    
    // * Summary *
    
    BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
    Intel Core i9-9980HK CPU 2.40GHz, 1 CPU, 16 logical and 8 physical cores
    .NET Core SDK=3.1.100
      [Host]     : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
      Job-RRTXQH : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
    
    Runtime=.NET Core 3.1
    
    |         Method |         x |             Mean |          Error |         StdDev | Ratio | Completed Work Items | Lock Contentions |       Gen 0 |     Gen 1 | Gen 2 |    Allocated |
    |--------------- |---------- |-----------------:|---------------:|---------------:|------:|---------------------:|-----------------:|------------:|----------:|------:|-------------:|
    | ActivatorTest1 |      1000 |        30.993 us |      0.7876 us |      0.8088 us |  1.00 |               0.0001 |                - |      4.7607 |         - |     - |     39.06 KB |
    | ActivatorTest2 |      1000 |         7.053 us |      0.0607 us |      0.0538 us |  0.23 |               0.0000 |                - |      4.7760 |         - |     - |     39.06 KB |
    |                |           |                  |                |                |       |                      |                  |             |           |       |              |
    | ActivatorTest1 |   1000000 |    27,691.175 us |    177.9530 us |    148.5988 us |  1.00 |               0.0625 |                - |   4781.2500 |         - |     - |  39064.19 KB |
    | ActivatorTest2 |   1000000 |     7,069.695 us |     99.0538 us |     92.6550 us |  0.26 |               0.0156 |                - |   4781.2500 |         - |     - |   39062.5 KB |
    |                |           |                  |                |                |       |                      |                  |             |           |       |              |
    | ActivatorTest1 | 100000000 | 2,785,181.093 us | 38,325.0183 us | 35,849.2459 us |  1.00 |               2.0000 |                - | 478000.0000 | 2000.0000 |     - | 3906418.4 KB |
    | ActivatorTest2 | 100000000 |   698,402.860 us |  5,697.2360 us |  5,329.1981 us |  0.25 |               2.0000 |                - | 478000.0000 |         - |     - |   3906250 KB |
    
    // * Hints *
    Outliers
      ActivatorBenchmark<TestClass>.ActivatorTest2: Runtime=.NET Core 3.1 -> 1 outlier  was  removed, 2 outliers were detected (6.92 us, 9.73 us)
      ActivatorBenchmark<TestClass>.ActivatorTest1: Runtime=.NET Core 3.1 -> 2 outliers were removed (28.56 ms, 29.78 ms)
    
    // * Legends *
      x                    : Value of the 'x' parameter
      Mean                 : Arithmetic mean of all measurements
      Error                : Half of 99.9% confidence interval
      StdDev               : Standard deviation of all measurements
      Ratio                : Mean of the ratio distribution ([Current]/[Baseline])
      Completed Work Items : The number of work items that have been processed in ThreadPool (per single operation)
      Lock Contentions     : The number of times there was contention upon trying to take a Monitor's lock (per single operation)
      Gen 0                : GC Generation 0 collects per 1000 operations
      Gen 1                : GC Generation 1 collects per 1000 operations
      Gen 2                : GC Generation 2 collects per 1000 operations
      Allocated            : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
      1 us                 : 1 Microsecond (0.000001 sec)
    
    // * Diagnostic Output - ThreadingDiagnoser *
    
    // * Diagnostic Output - MemoryDiagnoser *

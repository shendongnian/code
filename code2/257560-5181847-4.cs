    public class Analytic
    {
        public enum Period { Daily, Monthly, Quarterly, Yearly };
        public Analytic()
        {
            this.Benchmarks = new List<IBenchmark>();
        }
        // define a custom UI type editor so we can display our list of benchmark
        [Editor(typeof(BenchmarkTypeEditor), typeof(UITypeEditor))]
        public IBenchmark Benchmark { get; set; }
        [Browsable(false)] // don't show in the property grid        
        public List<IBenchmark> Benchmarks { get; private set; }
        public Period Periods { get; set; }
        public void AddBenchmark(IBenchmark benchmark)
        {
            if (!this.Benchmarks.Contains(benchmark))
            {
                this.Benchmarks.Add(benchmark);
            }
        }
    }
